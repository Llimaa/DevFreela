using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using DevFreela.Core.Service;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IPaymentService _paymentService;

        public FinishProjectCommandHandler(IProjectRepository projectRepository, IPaymentService paymentService)
        {
            _projectRepository = projectRepository;
            _paymentService = paymentService;
        }

        public async Task<Unit> Handle(FinishProjectCommand command, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetDetailsByIdAsync(command.Id);

            var paymentInfoDto = new PaymentInfoDTO(command.Id, command.CreditCardNumber, command.Cvv, command.ExpiresAt, command.FullName);

            _paymentService.ProcessPayment(paymentInfoDto);

            project.SetPaymentPending();

            await _projectRepository.FinishAsync(project);

            return Unit.Value;
        }
    }
}
