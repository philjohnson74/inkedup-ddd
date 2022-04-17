using System;
using System.Threading.Tasks;
using InkedUp.Domain;
using InkedUp.Framework;
using InkedUp.Api.Contracts;

namespace InkedUp.Api.Services
{
    public class PensApplicationService
        : IApplicationService
    {
        private readonly IPenRepository _repository;

        public PensApplicationService(
            IPenRepository repository
        )
        {
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                Pens.V1.Create cmd =>
                    HandleCreate(cmd),
                Pens.V1.UpdateManufacturer cmd =>
                    HandleUpdate(
                        cmd.Id,
                        cmd.OwnerId,
                        c => c.UpdateManufacturer(
                            PenManufacturer.FromString(cmd.Manufacturer)
                        )
                    ),
                Pens.V1.UpdateModel cmd =>
                    HandleUpdate(
                        cmd.Id,
                        cmd.OwnerId,
                        c => c.UpdateModel(
                            PenModel.FromString(cmd.Model)
                        )
                    ),
                Pens.V1.InkUp cmd =>
                    HandleUpdate(
                        cmd.Id,
                        cmd.OwnerId,
                        c => c.InkUp(
                            PenInkName.FromString(cmd.InkName)
                        )
                    ),
                Pens.V1.Flush cmd =>
                    HandleUpdate(
                        cmd.Id,
                        cmd.OwnerId,
                        c => c.Flush()
                    ),
                Pens.V1.Delete cmd =>
                    HandleUpdate(
                        cmd.Id,
                        cmd.OwnerId,
                        c => c.Delete()
                    ),
                _ => Task.CompletedTask
            };

        private async Task HandleCreate(Pens.V1.Create cmd)
        {
            if (await _repository.Exists(cmd.Id.ToString(), cmd.OwnerId.ToString()))
                throw new InvalidOperationException($"Entity with id {cmd.Id} already exists");

            var pen = new Pen(
                new PenId(cmd.Id),
                new UserId(cmd.OwnerId)
            );

            await _repository.Save(pen);
        }

        public async Task<Pen> HandleGet(Pens.V1.Get cmd)
        {
            var pen = await _repository.Load(cmd.Id.ToString(), cmd.OwnerId.ToString());
            return pen;
        }

        private async Task HandleUpdate(
            Guid penId,
            Guid ownerId,
            Action<Pen> operation
        )
        {
            var pen = await _repository.Load(
                penId.ToString(), ownerId.ToString()
            );
            if (pen == null)
                throw new InvalidOperationException(
                    $"Entity with id {penId} cannot be found"
                );

            operation(pen);

            await _repository.Save(pen);
        }
    }
}