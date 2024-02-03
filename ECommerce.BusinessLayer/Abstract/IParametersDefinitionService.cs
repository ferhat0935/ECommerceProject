using ECommerce.Common.Enums;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DtoLayer.DTOS;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Abstract
{
    public interface IParametersDefinitionService : IGenericService<ParameterDefinition>
    {

        public Task<List<ParameterDefinition>> GetParameters(string parameterCode);
    }
}
