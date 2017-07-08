using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace ContosoUniversity.Authorization
{
    public class InstructorIsOwnerAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement,
        Models.Department>
    {
        UserManager<ApplicationUser> _userManager;

        public InstructorIsOwnerAuthorizationHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager; 
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Department resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.FromResult(0);
            }

            //if we are not asking for CRUD permissions return
            if (requirement.Name != Constants.CreateOperationName &&
                //requirement.Name != Constants.ReadOperationName &&
                requirement.Name != Constants.UpdateOperationName &&
                requirement.Name != Constants.DeleteOperationName)
            {
                return Task.FromResult(0);
            }
            if (resource.InstructorID == null)
            {

            }

            if (resource.Administrator.UserId == _userManager.GetUserId(context.User))
            {
                context.Succeed(requirement);
            }
            return Task.FromResult(0);
        }
    }

    public class Constants
    {
        public static readonly string CreateOperationName = "Create";
        public static readonly string ReadOperationName = "Read";
        public static readonly string UpdateOperationName = "Update";
        public static readonly string DeleteOperationName = "Delete";
        public static readonly string ApproveOperationName = "Approve";
        public static readonly string RejectOperationName = "Reject";
        public static readonly string ContactAdministratorsRole = "ContactAdministrators";
        public static readonly string ContactManagersRole = "ContactManagers";
        public static readonly string ContactUserPolicy = "ContactUserPolicy";
    }
    public static class DepartmentOperations
    {
        public static OperationAuthorizationRequirement Create =
          new OperationAuthorizationRequirement { Name = Constants.CreateOperationName };
        public static OperationAuthorizationRequirement Read =
          new OperationAuthorizationRequirement { Name = Constants.ReadOperationName };
        public static OperationAuthorizationRequirement Update =
          new OperationAuthorizationRequirement { Name = Constants.UpdateOperationName };
        public static OperationAuthorizationRequirement Delete =
          new OperationAuthorizationRequirement { Name = Constants.DeleteOperationName };
        public static OperationAuthorizationRequirement Approve =
          new OperationAuthorizationRequirement { Name = Constants.ApproveOperationName };
        public static OperationAuthorizationRequirement Reject =
          new OperationAuthorizationRequirement { Name = Constants.RejectOperationName };
    }
}
