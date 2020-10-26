﻿using backend.DataAccess.Database.Entities;
using backend.DataAccess.Database.Repositories.Contracts;
using backend.Exceptions;
using backend.Models.Request;
using backend.Services.Builder;
using backend.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Impl
{
    public class TargetSettingService : ITargetSettingService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IEntityBuilder _entityBuilder;
        private readonly IProjectExpenditureRepository _projectExpenditureRepository;
        private readonly IProjectTodoRepository _projectTodoRepository;
        private readonly IProjectProgressRepository _projectProgressRepository;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IInvoiceRepository _invoiceRepo;
        private readonly ITargetSettingRepository _targetSettingRepo;

        public TargetSettingService(ITargetSettingRepository targetSettingRepo,IInvoiceRepository invoiceRepo, IEmployeesRepository employeesRepository, IProjectRepository projectRepository, IEntityBuilder entityBuilder, IProjectExpenditureRepository _projectExpenditureRepository, IProjectTodoRepository _projectTodoRepository, IProjectProgressRepository _projectProgressRepository)
        {
            _entityBuilder = entityBuilder;
            _projectRepository = projectRepository;
            _employeesRepository = employeesRepository;
            this._projectExpenditureRepository = _projectExpenditureRepository;
            this._projectProgressRepository = _projectProgressRepository;
            this._projectTodoRepository = _projectTodoRepository;
            this._invoiceRepo = invoiceRepo;
            this._targetSettingRepo = targetSettingRepo;
        }

        public bool CreateTargetSetting(TargetSettingModel targetSetting)
        {
            TargetSettingsEntity target = new TargetSettingsEntity
            {
                id = 0,
                title = targetSetting.title,
                overallTarget = targetSetting.overallTarget,
                q1_actual = targetSetting.q1_actual,
                q1_target = targetSetting.q1_target,
                q2_actual = targetSetting.q2_actual,
                q2_target = targetSetting.q2_target,
                q3_actual = targetSetting.q3_actual,
                q3_target = targetSetting.q3_target,
                q4_actual = targetSetting.q4_actual,
                q4_target = targetSetting.q4_target
            };

            return _targetSettingRepo.Save(target);
        }

        public bool DeleteTargetSetting(int id)
        {
            TargetSettingsEntity target = _targetSettingRepo.GetById(id);
            if(target != null)
            {
                return _targetSettingRepo.Delete(target);
            }

            throw new McpCustomException("Could not find target id " + id);
        }

        public List<TargetSettingModel> GetAll()
        {
            List<TargetSettingsEntity> targets = _targetSettingRepo.GetAll();
            List<TargetSettingModel> result = new List<TargetSettingModel>();

            if(targets.Count != 0)
            {
                foreach (TargetSettingsEntity target in targets)
                {
                    result.Add(new TargetSettingModel
                    {
                        id = target.id,
                        title = target.title,
                        overallTarget = target.overallTarget,
                        q1_actual = target.q1_actual,
                        q1_target = target.q1_target,
                        q2_actual = target.q2_actual,
                        q2_target = target.q2_target,
                        q3_actual = target.q3_actual,
                        q3_target = target.q3_target,
                        q4_actual = target.q4_actual,
                        q4_target = target.q4_target
                    });
                }

            }

            return result;
        }

        public TargetSettingModel GetTargetSetting(string title)
        {
            TargetSettingsEntity target = _targetSettingRepo.GetByTitle(title);
            if(target != null)
            {
                return new TargetSettingModel
                {
                    id = target.id,
                    title = target.title,
                    overallTarget = target.overallTarget,
                    q1_actual = target.q1_actual,
                    q1_target = target.q1_target,
                    q2_actual = target.q2_actual,
                    q2_target = target.q2_target,
                    q3_actual = target.q3_actual,
                    q3_target = target.q3_target,
                    q4_actual = target.q4_actual,
                    q4_target = target.q4_target
                };
            }

            throw new McpCustomException("Target setting with title " + title + " was not found");
        }

        public TargetSettingModel GetTargetSetting(int id)
        {
            TargetSettingsEntity target = _targetSettingRepo.GetById(id);
            if (target != null)
            {
                return new TargetSettingModel
                {
                    id = target.id,
                    title = target.title,
                    overallTarget = target.overallTarget,
                    q1_actual = target.q1_actual,
                    q1_target = target.q1_target,
                    q2_actual = target.q2_actual,
                    q2_target = target.q2_target,
                    q3_actual = target.q3_actual,
                    q3_target = target.q3_target,
                    q4_actual = target.q4_actual,
                    q4_target = target.q4_target
                };
            }

            throw new McpCustomException("Target setting with ID " + id + " was not found");
        }

        public bool UpdateTargetSetting(TargetSettingModel targetSetting)
        {
            TargetSettingsEntity target = _targetSettingRepo.GetById(targetSetting.id);
            if (target != null)
            {
                return _targetSettingRepo.Update(target);
            }

            throw new McpCustomException("Target setting with id " + target.id + " was not found");
        }
    }
}
