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
        private readonly IValidator<TutoringPostRequestDto> _tutoringPostValidator;
        private readonly IRepository<Data.Models.TutoringPost, long> _tutoringPostRepository;
        private readonly IFieldService _fieldService;
        private readonly IUserService _userService;
        private readonly ILogger<TutoringPostService> _logger;

        public TutoringPostService(
            IValidator<TutoringPostRequestDto> tutoringPostValidator,
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

        public async Task<(ServiceActionResult Result, TutoringPostResponseDto? Created)> CreateTutoringPostAsync(TutoringPostRequestDto creationRequestDto)
        {
            await _tutoringPostValidator.ValidateAndThrowAsync(creationRequestDto);

            var mapped = creationRequestDto.ToModel();

            var (subjectKey, fieldKeys) = await _fieldService.GetSubjectAndFieldKeys(
                creationRequestDto.SubjectName,
                creationRequestDto.Fields);

            fieldKeys
                .ForEach(key => mapped.Fields
                    .Add(new Data.Models.TutoringPostField
                    {
                        FieldId = key,
                    }));

            var tutor = await _userService.GetTutorAsync(creationRequestDto.TutorUsername);
            mapped.TutorId = tutor.Id;
            mapped.IsPaidAd = false; // TODO: Implement stripe integration

            var (result, created) = await _tutoringPostRepository.CreateAsync(mapped);

            if (result is not Data.Enums.RepositoryActionResult.Success)
                return (ServiceActionResult.Failed, null);

            return (ServiceActionResult.Created, created!.ToDto());
        }

        public async Task<TutoringPostResponseDto> GetTutoringPostAsync(long id, CancellationToken cancellationToken = default)
        {
            var tutoringPost = await _tutoringPostRepository.Query()
                .Where(x => x.Id == id)
                .ProjectToDto()
                .FirstOrDefaultAsync(cancellationToken);

            return tutoringPost ?? throw new NotFoundException<Data.Models.TutoringPost>(id);
        }

        public async Task<ICollection<TutoringPostResponseDto>> GetTutoringPostsAsync(
            string countryName,
            string regionName,
            PaginationRequestDto? paginationOptions = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default)
        {
            var tutoringPosts = await _tutoringPostRepository.Query()
                .Where(tutoringPost =>
                    tutoringPost.Tutor.City.Region.Name == regionName.ToNormalizedLower()
                    && tutoringPost.Tutor.City.Region.Country.Name == countryName.ToNormalizedLower())
                .Where(tutoringPost => tutoringPost.AvailableTimeFrames
                    .Any(timeFrame => timeFrame.Start > DateTime.UtcNow.Add(timeFrame.Start.Offset)))
                .SortTutoringPosts(sortOptions ?? new SortRequestDto { SortByProperty = SortByProperty.Rating, SortOrder = SortOrder.Descending })
                .Paginate(paginationOptions ?? new PaginationRequestDto { Skip = 0, Take = 25 })
                .ProjectToDto()
                .ToListAsync(cancellationToken);

            return tutoringPosts;
        }

        public async Task<ICollection<TutoringPostResponseDto>> GetAvailableTutoringPostsAsync(
            string countryName,
            string regionName,
            PaginationRequestDto? paginationOptions = null,
            SortRequestDto? sortOptions = null,
            CancellationToken cancellationToken = default)
        {
            var tutoringPosts = await _tutoringPostRepository.Query()
                .Where(tutoringPost =>
                    tutoringPost.Tutor.City.Region.Name == regionName.ToNormalizedLower()
                    && tutoringPost.Tutor.City.Region.Country.Name == countryName.ToNormalizedLower())
                .Where(tutoringPost => tutoringPost.AvailableTimeFrames
                    .Any(timeFrame => timeFrame.Start > DateTime.UtcNow.Add(timeFrame.Start.Offset)))
                .Where(tutoringPost => tutoringPost.AvailableTimeFrames
                    .Any(timeFrame => timeFrame.TakenByStudent == null))
                .SortTutoringPosts(sortOptions ?? new SortRequestDto { SortByProperty = SortByProperty.Rating, SortOrder = SortOrder.Descending })
                .Paginate(paginationOptions ?? new PaginationRequestDto { Skip = 0, Take = 25 })
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

        public async Task<bool> IsPartOfPostAsync(
            long appointmentId,
            long postId,
            CancellationToken cancellationToken = default)
        {
            return await _tutoringPostRepository.Query()
                .AnyAsync(tutoringPost =>
                    tutoringPost.Id == postId
                    && tutoringPost.Appointments.Any(appointment =>
                        appointment.Id == appointmentId),
                    cancellationToken);
        }
    }
}
