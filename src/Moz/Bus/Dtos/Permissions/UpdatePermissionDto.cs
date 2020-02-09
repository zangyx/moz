﻿using System.Linq;
using FluentValidation;
using FluentValidation.Attributes;
using Moz.Bus.Services.Localization;
using Moz.Validation;

namespace Moz.Bus.Dtos.Permissions
{
    /// <summary>
    /// tab_permission
    /// </summary>
    [Validator(typeof(UpdatePermissionDtoValidator))]
    public class UpdatePermissionDto
    {
        #region 属性
        
        /// <summary>
        /// 
        /// </summary>
        public long Id { get;set; } 
        
        /// <summary>
        /// 
        /// </summary>
        public string Name { get;set; } 
        
        /// <summary>
        /// 
        /// </summary>
        public string Code { get;set; } 
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get;set; } 
        
        /// <summary>
        /// 
        /// </summary>
        public long? ParentId
        {
            get
            {

                if (string.IsNullOrEmpty(ParentIdsStr)) return null;
                var ids = ParentIdsStr.Split(',')
                    .Where(t => !string.IsNullOrEmpty(t) && t.All(char.IsDigit))
                    .Select(long.Parse).ToArray();
                if (ids.Any()) return ids.Last();
                return null;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ParentIdsStr { get; set; } 
        
        
        #endregion     
    }
    
    
    public class UpdatePermissionDtoValidator : MozValidator<UpdatePermissionDto>
    {
        public UpdatePermissionDtoValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("发生错误");
            RuleFor(x => x.Name).NotEmpty().WithMessage("标题不能为空");
            RuleFor(x => x.Code).NotEmpty().WithMessage("标识码不能为空");
        }
    }
    
}
