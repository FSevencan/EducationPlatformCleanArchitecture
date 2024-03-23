using Application.Features.UserAnswers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.UserAnswers.Rules;

public class UserAnswerBusinessRules : BaseBusinessRules
{
    private readonly IUserAnswerRepository _userAnswerRepository;

    public UserAnswerBusinessRules(IUserAnswerRepository userAnswerRepository)
    {
        _userAnswerRepository = userAnswerRepository;
    }

    public Task UserAnswerShouldExistWhenSelected(UserAnswer? userAnswer)
    {
        if (userAnswer == null)
            throw new BusinessException(UserAnswersBusinessMessages.UserAnswerNotExists);
        return Task.CompletedTask;
    }

    public async Task UserAnswerIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        UserAnswer? userAnswer = await _userAnswerRepository.GetAsync(
            predicate: ua => ua.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await UserAnswerShouldExistWhenSelected(userAnswer);
    }
}