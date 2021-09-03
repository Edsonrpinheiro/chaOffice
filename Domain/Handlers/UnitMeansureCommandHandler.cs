using Domain.Commands.UnitMeansureCommands;
using Domain.Commands.Results;
using Domain.Entities;
using Domain.Repositories;
using Shared.Commands;
using Shared.Handlers;

namespace Domain.Handlers
{
    public class UnitMeansureCommandHandler :
    IHandler<CreateUnitMeansureCommand>,
    IHandler<UpdateUnitMeansureCommand>,
    IHandler<DeleteUnitMeansureCommand>
    {
        private readonly IUnitMeansureRepository _unitMeansureRepository;
        public UnitMeansureCommandHandler(IUnitMeansureRepository unitMeansureRepository)
        {
            _unitMeansureRepository = unitMeansureRepository;
        }

        public ICommandResult Handler(CreateUnitMeansureCommand command)
        {
            var unitMeansureExists = _unitMeansureRepository.UnitMeansureExists(command.Name);

            if (unitMeansureExists)
                return new GenericCommandResult("Unidade de medida já criada anteriormente", false);

            var unitMeansure = new UnitMeansure(command.Name, command.Acronym);
            _unitMeansureRepository.Add(unitMeansure);
            _unitMeansureRepository.Save();

            return new GenericCommandResult("Unidade de medida criada com sucesso", true);
        }

        public ICommandResult Handler(UpdateUnitMeansureCommand command)
        {
            var unitMeansureNameAlreadyExists = _unitMeansureRepository.UnitMeansureExists(command.Name, command.Id);

            if (unitMeansureNameAlreadyExists)
                return new GenericCommandResult("Unidade de medida já criada anteriormente", false);

            var unitMeansure = _unitMeansureRepository.Get(command.Id);            
            unitMeansure.Update(command.Name, command.Acronym);
            _unitMeansureRepository.Save();

            return new GenericCommandResult("Unidade de medida atualizada com sucesso", true);
        }

        public ICommandResult Handler(DeleteUnitMeansureCommand command)
        {
            var unitMeansure = _unitMeansureRepository.Get(command.Id);
            var unitMeansureInUse = _unitMeansureRepository.UnitMeansureInUse(unitMeansure);

            if (unitMeansureInUse)
                return new GenericCommandResult("Unidade de medida já criada anteriormente", false);

            unitMeansure.Deactivate();
            _unitMeansureRepository.Save();

            return new GenericCommandResult("Unidade de medida Inativada com sucesso", true);
        }
    }
}