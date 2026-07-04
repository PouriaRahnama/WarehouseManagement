using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Domain.Enums;

namespace WarehouseManagement.Infrastructure.Common;

public static class SeedData
{
    public static IEnumerable<User> DefaultUsers =>
      new List<User>
      {
            new User
            {
                Id = Guid.Parse("6712adb7-a20d-43e9-8b29-357271f3bd65"),
                Username = "AdminUser",
                PasswordHash = "3c830e2af2e5db02e2f467634499d3c807e7b0c1b09c247a478c893703999b0e",  //123456
                PasswordSalt = "6081de2f-df32-4e79-a844-772054b8fb32",
                Phone = "09121234567",
                Role = UserRole.Admin

            },
            new User
            {
                Id = Guid.Parse("92aa3814-ee96-4593-bdd3-cd613268137a"),
                Username = "OperatorUser2",
                PasswordHash = "3c830e2af2e5db02e2f467634499d3c807e7b0c1b09c247a478c893703999b0e", //123456
                PasswordSalt = "6081de2f-df32-4e79-a844-772054b8fb32",
                Phone = "09139876543",
                Role = UserRole.Operator
            }
      };
}

