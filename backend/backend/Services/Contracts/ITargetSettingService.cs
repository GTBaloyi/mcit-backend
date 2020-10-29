﻿using backend.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services.Contracts
{
    public interface ITargetSettingService
    {
        public bool CreateTargetSetting(TargetSettingModel targetSetting);
        public bool UpdateTargetSetting(TargetSettingModel targetSetting);
        public bool DeleteTargetSetting(int id);
        public List<TargetSettingModel> GetAll();
        public List<TargetSettingModel> GetTargetSetting(string title);
        public List<TargetSettingModel> GetCategory(string title);
        public TargetSettingModel GetTargetSetting(int id);
    }
}
