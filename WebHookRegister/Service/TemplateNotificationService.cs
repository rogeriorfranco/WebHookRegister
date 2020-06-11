using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebHookRegister.Domain.Entities;
using WebHookRegister.Domain.Enums;
using WebHookRegister.Domain.Request;
using WebHookRegister.Domain.Response;
using WebHookRegister.Infra.Repositories.Interfaces;
using WebHookRegister.Service.Interfaces;

namespace WebHookRegister.Service
{
    public class TemplateNotificationService : ITemplateNotificationService
    {
        public ITemplateNotificationRepository _iTemplateNotificationRepository { get; }
        public IMapper _mapper { get; }
        public TemplateNotificationService(ITemplateNotificationRepository iEventRepository, IMapper mapper)
        {
            _iTemplateNotificationRepository = iEventRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TemplateNotificationResponse>> GetByEventAsync(Event name)
        {
            var template = await _iTemplateNotificationRepository.GetByEventAsync(name);

            return _mapper.Map<IEnumerable<TemplateNotificationResponse>>(template);
        }
        public async Task<TemplateNotificationResponse> InsertAsync(TemplateNotificationRequest templateNotification)
        {
            var mappedTemplateNotification = _mapper.Map<TemplateNotification>(templateNotification);

            var template = await _iTemplateNotificationRepository.InsertAsync(mappedTemplateNotification);

            return _mapper.Map<TemplateNotificationResponse>(template);
        }
        public async Task<bool> DeleteByIdAsync(long idTemplateNotification)
        {
            var delete = await _iTemplateNotificationRepository.DeleteByIdAsync(idTemplateNotification);
            return delete > 0 ? true : false;
        }
    }

}
