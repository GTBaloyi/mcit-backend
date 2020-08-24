﻿using backend.DataAccess.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataAccess.Database.Repositories.Contracts
{
    interface IProjectExpenditureRepository
    {
        List<ProjectExpenditure> GetAll();
        ProjectExpenditure GetById(int id);
        ProjectExpenditure GetByProjectNumber(string projectNumber);
        List<ProjectExpenditure> GetByProjectStatus(string focusArea);
        List<ProjectExpenditure> GetByStartQuarter(string item);
        bool Update(ProjectExpenditure projectExpenditure);
        bool Delete(ProjectExpenditure projectExpenditure);
        bool Insert(ProjectExpenditure projectExpenditure);
    }
}