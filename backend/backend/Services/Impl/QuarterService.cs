using backend.DataAccess.Database.Entities;
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
    public class QuarterService : IQuarterService
    {
        private readonly IQuarterRepository _quarterRepository;
        private readonly IEntityBuilder _entityBuilder;

      
        public QuarterService(IQuarterRepository quarterRepository, IEntityBuilder entityBuilder)
        {
            _quarterRepository = quarterRepository;
            _entityBuilder = entityBuilder;
        }


        public bool DeleteQuarter(QuarterModel quarter)
        {
            QuarterEntity quarterEntity = _entityBuilder.buildQuarterEntity(quarter.id, quarter.quarter, quarter.startDate, quarter.endDate);
            if (_quarterRepository.GetById(quarterEntity.id) != null)
            {
                return _quarterRepository.Delete(quarterEntity);
            }

            throw new McpCustomException("There is no quarter associated with the ID: " + quarter.id);
        }

        public List<QuarterModel> GetAll()
        {
            List<QuarterEntity> quarters = _quarterRepository.GetAll();
            List<QuarterModel> results = new List<QuarterModel>();

            foreach (QuarterEntity q in quarters)
            {
                results.Add(new QuarterModel
                {
                    id = q.id,
                    quarter = q.quarter,
                    startDate = q.start_date,
                    endDate = q.end_date
                });
            }

            return results;
        }

        public QuarterModel GetById(int id)
        {
            QuarterEntity quarters = _quarterRepository.GetById(id);
            if(quarters !=null)
            {
                return new QuarterModel
                {
                    id = quarters.id,
                    quarter = quarters.quarter,
                    startDate = quarters.start_date,
                    endDate = quarters.end_date
                };
            }

            throw new McpCustomException("Quarter with ID " + id + " does not exist");
          
        }

        public QuarterModel GetByQuarter(string quarter)
        {
            QuarterEntity quarters = _quarterRepository.GetByQuarter(quarter);
            if (quarters != null)
            {
                return new QuarterModel
                {
                    id = quarters.id,
                    quarter = quarters.quarter,
                    startDate = quarters.start_date,
                    endDate = quarters.end_date
                };
            }

            throw new McpCustomException("Quarter " + quarter + " does not exist");
        }

        public bool InsertQuarter(QuarterModel quarter)
        {
            QuarterEntity quarterEntity = _entityBuilder.buildQuarterEntity(0, quarter.quarter, quarter.startDate, quarter.endDate);
            return _quarterRepository.Insert(quarterEntity);
        }

        public bool UpdateQuarter(QuarterModel quarter)
        {
            if (_quarterRepository.GetById(quarter.id) != null)
            {
                QuarterEntity quarterEntity = _entityBuilder.buildQuarterEntity(quarter.id, quarter.quarter, quarter.startDate, quarter.endDate);
                return _quarterRepository.Update(quarterEntity);
            }

            throw new McpCustomException("Quarter with id " + quarter.id + " does not exist");
        }
    }
}
