using ECommerce.BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DtoLayer.DTOS;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Concrete
{
	public class ParametersDefinitionManager : IParametersDefinitionService
	{
		private readonly IParameterDefinitonDal _parametersDefinitonDal;

		public ParametersDefinitionManager(IParameterDefinitonDal parametersDefinitonDal)
		{
			_parametersDefinitonDal = parametersDefinitonDal;
		}

        public async Task<List<ParamaterDefinitionDto>> GetColorSize(string parameterColor, string parameterSize)
        {
            var result = await _parametersDefinitonDal.FilterAsync(s => s.ParameterGroupName == "Color" || s.ParameterGroupName == "Size");

            var data = result
                .Select(s => new ParamaterDefinitionDto
                {
                    Id = s.Id,
                    ParameterGroupName = s.ParameterGroupName,
                    ParameterName = s.ParameterName,
                    ParameterValue = s.ParameterValue,
                    ColorCode = s.ColorCode,
                    IsActive = s.IsActive,
                })
                .ToList();

            return data;
        }


  //      public async Task<List<ParameterDefinition>> GetParameters(string parameterCode)
		//{
		//	var data = await _parametersDefinitonDal.FilterAsync(s => s.ParameterGroupName == parameterCode);
		//	return data.ToList();
		//}

		public void TCreate(ParameterDefinition entity)
		{
			_parametersDefinitonDal.Create(entity);
		}

		public void TDelete(ParameterDefinition entity)
		{
			_parametersDefinitonDal.Delete(entity);
		}

		public Task<IEnumerable<ParameterDefinition>> TFilterAsync(Expression<Func<ParameterDefinition, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ParameterDefinition>> TFindByConditionAsync(Expression<Func<ParameterDefinition, bool>> expression, params Expression<Func<ParameterDefinition, object>>[] includeProperties)
		{
			throw new NotImplementedException();
		}

		public List<ParameterDefinition> TGetAll()
		{
			return _parametersDefinitonDal.GetAll();	
		}

		public Task<ParameterDefinition> TGetByIdAsync(object id)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(ParameterDefinition entity)
		{
			_parametersDefinitonDal.Update(entity);
		}
	}
}
