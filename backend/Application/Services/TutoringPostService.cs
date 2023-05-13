using Application.Dtos.Common;
using Application.Dtos.TutoringPost;
using Application.Enums;
using Application.Exceptions;
using Application.Extensions;
using Application.Interfaces;
using Application.TutoringPost;
using Data.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class TutoringPostService : ITutoringPostService
    {
        private readonly IValidator<RequestDto> _tutoringPostValidator;
        private readonly IRepository<Data.Models.TutoringPost, long> _tutoringPostRepository;
        private readonly IFieldService _fieldService;
        private readonly IUserService _userService;
        private readonly ILogger<TutoringPostService> _logger;

        public TutoringPostService(
            IValidator<RequestDto> tutoringPostValidator,
            IRepository<Data.Models.TutoringPost, long> tutoringPostRepository,
            IFieldService fieldService,
            IUserService userService,
            ILogger<TutoringPostService> logger)
        {
            _tutoringPostValidator = tutoringPostValidator;
            _tutoringPostRepository = tutoringPostRepository;
            _fieldService = fieldService;
            _userService = userService;
            _logger = logger;
        }

        public async Task<(ServiceActionResult Result, ResponseDto? Created)> CreateTutoringPostAsync(RequestDto creationRequestDto)
        {
            await _tutoringPostValidator.ValidateAndThrowAsync(creationRequestDto);

            var mapped = creationRequestDto.ToModel();

            var (SubjectKey, FieldKeys) = await _fieldService.GetSubjectAndFieldKeys(
                creationRequestDto.SubjectName,
                creationRequestDto.Fields);

            FieldKeys
                .ForEach(key => mapped.Fields
                    .Add(new Data.Models.TutoringPostField
                    {
                        FieldId = key,
                    }));

            var tutor = await _userService.GetTutorAsync(creationRequestDto.TutorUsername);
            mapped.TutorId = tutor.Id;
            mapped.IsPaidAd = false; // TODO implement stripe integration

            var creationResult = await _tutoringPostRepository.CreateAsync(mapped);

            if (creationResult.Result is not Data.Enums.RepositoryActionResult.Success)
                return (ServiceActionResult.Failed, null);
            return (ServiceActionResult.Created, creationResult.Created!.ToDto());
        }

        public async Task<ResponseDto> GetTutoringPostAsync(long id, CancellationToken cancellationToken = default)
        {
            var tutoringPost = await _tutoringPostRepository.Query()
                .Where(x => x.Id == id)
                .ProjectToDto()
                .FirstOrDefaultAsync(cancellationToken);

            return tutoringPost ?? throw new NotFoundException<Data.Models.TutoringPost>(id);
        }

        public async Task<ICollection<ResponseDto>> GetTutoringPostsAsync(
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            RequestPaginationDto? paginationOptions = null,
            RequestSortDto? sortOptions = null,
            CancellationToken cancellationToken = default)
        {
            var tutoringPosts = await _tutoringPostRepository.Query()
                .Where(tutoringPost => tutoringPost.AvailableTimeSpans
                    .Any(timeSpan => timeSpan.Start > DateTime.UtcNow.Add(timeSpan.Start.Offset)))
                .SortTutoringPosts(sortOptions ?? new RequestSortDto { SortByProperty = SortByProperty.Rating, SortOrder = SortOrder.Descending })
                .Paginate(paginationOptions ?? new RequestPaginationDto { Skip = 0, Take = 25 })
                .ProjectToDto()
                .ToListAsync(cancellationToken);

            return tutoringPosts;
        }

        public async Task<ICollection<ResponseDto>> GetAvailableTutoringPostsAsync(
            string? countryName = null,
            string? regionName = null,
            string? cityName = null,
            RequestPaginationDto? paginationOptions = null,
            RequestSortDto? sortOptions = null,
            CancellationToken cancellationToken = default)
        {
            var tutoringPosts = await _tutoringPostRepository.Query()
                .Where(tutoringPost => tutoringPost.AvailableTimeSpans
                    .Any(timeSpan => timeSpan.Start > DateTime.UtcNow.Add(timeSpan.Start.Offset)))
                .Where(tutoringPost => tutoringPost.AvailableTimeSpans
                    .Any(timeSpan => timeSpan.TakenByStudent == null))
                .SortTutoringPosts(sortOptions ?? new RequestSortDto { SortByProperty = SortByProperty.Rating, SortOrder = SortOrder.Descending })
                .Paginate(paginationOptions ?? new RequestPaginationDto { Skip = 0, Take = 25 })
                .ProjectToDto()
                .ToListAsync(cancellationToken);

            return tutoringPosts;
        }

        public async Task<bool> TutoringPostExistsAsync(
            long tutoringPost,
            CancellationToken cancellationToken = default)
        {
            var result = await GetTutoringPostAsync(tutoringPost, cancellationToken);

            return result is not null;
        }
    }
}
