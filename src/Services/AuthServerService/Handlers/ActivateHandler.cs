﻿using System.Threading.Tasks;
using AlbedoTeam.Identity.Contracts.Commands;
using AlbedoTeam.Sdk.FailFast;
using AlbedoTeam.Sdk.FailFast.Abstractions;
using AlbedoTeam.Sdk.MessageProducer.Services.Abstractions;
using Identity.Api.Mappers.Abstractions;
using Identity.Api.Models;
using Identity.Api.Services.AuthServerService.Requests;

namespace Identity.Api.Services.AuthServerService.Handlers
{
    public class ActivateHandler : CommandHandler<Activate, AuthServer>
    {
        private readonly IAuthServerMapper _mapper;
        private readonly IProducerService _producer;

        public ActivateHandler(IProducerService producer, IAuthServerMapper mapper)
        {
            _producer = producer;
            _mapper = mapper;
        }

        protected override async Task<Result<AuthServer>> Handle(Activate request)
        {
            await _producer.Send<ActivateAuthServer>(_mapper.MapRequestToCommand(request));
            return new Result<AuthServer>();
        }
    }
}