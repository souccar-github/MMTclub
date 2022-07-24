using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Ahc.Club.Authorization
{
    public class ExchangeAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            //Users
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Create);
            context.CreatePermission(PermissionNames.Pages_Users_Edit, L("EditUser"));
            context.CreatePermission(PermissionNames.Pages_Users_Delete, L("DeleteUser"));
            context.CreatePermission(PermissionNames.Pages_Users_ResetPassword, L("ResetPassword"));
            context.CreatePermission(PermissionNames.Pages_Users_ChangePermissions, L("ChangePermissions"));

            //Roles
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Roles_Create, L("CreateNewRole"));
            context.CreatePermission(PermissionNames.Pages_Roles_Edit, L("EditRole"));
            context.CreatePermission(PermissionNames.Pages_Roles_Delete, L("DeleteRole"));



            //QrCodes
            context.CreatePermission(PermissionNames.Pages_QrCodes, L("QrCode"));
            context.CreatePermission(PermissionNames.Actions_QrCodes_Create, L("CreateNewQrCode"));
            context.CreatePermission(PermissionNames.Actions_QrCodes_Update, L("EditQrCode"));
            context.CreatePermission(PermissionNames.Actions_QrCodes_Delete, L("DeleteQrCode"));

            //Products
            context.CreatePermission(PermissionNames.Pages_Products, L("Product"));
            context.CreatePermission(PermissionNames.Actions_Products_Create, L("CreateNewProduct"));
            context.CreatePermission(PermissionNames.Actions_Products_Update, L("EditProduct"));
            context.CreatePermission(PermissionNames.Actions_Products_Delete, L("DeleteProduct"));

            //ProductImages
            context.CreatePermission(PermissionNames.Pages_ProductImages, L("ProductImage"));
            context.CreatePermission(PermissionNames.Actions_ProductImages_Create, L("CreateNewProductImage"));
            context.CreatePermission(PermissionNames.Actions_ProductImages_Update, L("EditProductImage"));
            context.CreatePermission(PermissionNames.Actions_ProductImages_Delete, L("DeleteProductImage"));

            //ProductSizes
            context.CreatePermission(PermissionNames.Pages_ProductSizes, L("ProductSize"));
            context.CreatePermission(PermissionNames.Actions_ProductSizes_Create, L("CreateNewProductSize"));
            context.CreatePermission(PermissionNames.Actions_ProductSizes_Update, L("EditProductSize"));
            context.CreatePermission(PermissionNames.Actions_ProductSizes_Delete, L("DeleteProductSize"));

            //Sizes
            context.CreatePermission(PermissionNames.Pages_Sizes, L("Size"));
            context.CreatePermission(PermissionNames.Actions_Sizes_Create, L("CreateNewSize"));
            context.CreatePermission(PermissionNames.Actions_Sizes_Update, L("EditSize"));
            context.CreatePermission(PermissionNames.Actions_Sizes_Delete, L("DeleteSize"));

            //Categories
            context.CreatePermission(PermissionNames.Pages_Categories, L("Category"));
            context.CreatePermission(PermissionNames.Actions_Categories_Create, L("CreateNewCategory"));
            context.CreatePermission(PermissionNames.Actions_Categories_Update, L("EditCategory"));
            context.CreatePermission(PermissionNames.Actions_Categories_Delete, L("DeleteCategory"));

            //Category News
            context.CreatePermission(PermissionNames.Pages_CategoryNews, L("CategoryNews"));
            context.CreatePermission(PermissionNames.Actions_CategoryNews_Create, L("CreateNewCategory"));
            context.CreatePermission(PermissionNames.Actions_CategoryNews_Update, L("EditCategory"));
            context.CreatePermission(PermissionNames.Actions_CategoryNews_Delete, L("DeleteCategory"));


        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ExchangeConsts.LocalizationSourceName);
        }
    }
}
