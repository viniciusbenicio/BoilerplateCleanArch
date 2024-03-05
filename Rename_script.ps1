$oldName = "BoilerplateCleanArch"
$path = "D:\Projetos\Pessoal\$oldName" 
$newName = "PicPay"
Get-ChildItem $path  -Recurse | Where-Object { $_.Name.Contains($oldName) } | Rename-Item -NewName { $_.Name -replace $oldName, $newName }


$arquivosSLNeCSPROJ = @(
    "$path\$newName.sln",
    "$path\$newName.API\$newName.API.csproj",
    "$path\$newName.Application\$newName.Application.csproj",
    "$path\$newName.Domain\$newName.Domain.csproj",
    "$path\$newName.Domain.Tests\$newName.Domain.Tests.csproj",
    "$path\$newName.Infra.IoC\$newName.Infra.IoC.csproj",
    "$path\$newName.Infra.Data\$newName.Infra.Data.csproj",
    "$path\$newName.WebUI\$newName.WebUI.csproj",
    "$path\$newName.Infra.IoC\DependencyInjectionAPI.cs",
    "$path\$newName.Infra.IoC\DependencyInjection.cs"
)

foreach ($filePath in $arquivosSLNeCSPROJ) {
    $content = Get-Content -Path $filePath
    $novoConteudo = $content -replace $oldName, $newName
    $novoConteudo | Set-Content -Path $filePath
}

$arquivosClass = @(
    # BoilerplateCleanArch.API
    "$path\$newName.API\Controllers\Category\CategoriesController.cs",
    "$path\$newName.API\Controllers\Product\ProductsController.cs",
    "$path\$newName.API\Controllers\Token\TokenController.cs",
    "$path\$newName.API\DTO\LoginDTO.cs",
    "$path\$newName.API\DTO\RegisterDTO.cs",
    "$path\$newName.API\DTO\UserTokenDTO.cs",
    "$path\$newName.API\Program.cs",
    "$path\$newName.API\Startup.cs",
    
    # BoilerplateCleanArch.Application
    "$path\$newName.Application\DTOS\CategoryDTO.cs",
    "$path\$newName.Application\DTOS\ProductDTO.cs",
    "$path\$newName.Application\Interfaces\ICategoryService.cs",
    "$path\$newName.Application\Interfaces\IProductService.cs",
    "$path\$newName.Application\Mappings\DomainToDTOMappingProfile.cs",
    "$path\$newName.Application\Mappings\DTOtoCommandMappingProfile.cs",
    "$path\$newName.Application\Products\Commands\ProductCommand.cs",
    "$path\$newName.Application\Products\Commands\ProductCreateCommand.cs",
    "$path\$newName.Application\Products\Commands\ProductRemoveCommand.cs",
    "$path\$newName.Application\Products\Commands\ProductUpdateCommand.cs",
    "$path\$newName.Application\Products\Handlers\GetProductByIdQueryHandler.cs",
    "$path\$newName.Application\Products\Handlers\GetProductsQueryHandler.cs",
    "$path\$newName.Application\Products\Handlers\ProductCreateCommandHandler.cs",
    "$path\$newName.Application\Products\Handlers\ProductRemoveCommandHandler.cs",
    "$path\$newName.Application\Products\Handlers\ProductUpdateCommandHandler.cs",
    "$path\$newName.Application\Products\Queries\GetProductsByIdQuery.cs",
    "$path\$newName.Application\Products\Queries\GetProductsQueries.cs",
    "$path\$newName.Application\Services\CategoryService.cs",
    "$path\$newName.Application\Services\ProductService.cs",

    # BoilerplateCleanArch.Domain
    "$path\$newName.Domain\Account\IAuthenticate.cs",
    "$path\$newName.Domain\Account\ISeedUserRoleInitial.cs",
    "$path\$newName.Domain\Account\IAuthenticate.cs",
    "$path\$newName.Domain\Account\ISeedUserRoleInitial.cs",
    "$path\$newName.Domain\Interfaces\ICategoryRepository.cs",
    "$path\$newName.Domain\Interfaces\IProductRepository.cs",
    "$path\$newName.Domain\Validation\DomainExceptionValidation.cs",
    "$path\$newName.Domain\Entities\Category.cs",
    "$path\$newName.Domain\Entities\Entity.cs",
    "$path\$newName.Domain\Entities\Product.cs",

    # BoilerplateCleanArch.Domain.Tests
    "$path\$newName.Domain.Tests\CategoryUnitTest1.cs",
    "$path\$newName.Domain.Tests\ProductUnitTest1.cs",

    # BoilerplateCleanArch.Infra.Data
    "$path\$newName.Infra.Data\Context\ApplicationDbContext.cs",
    "$path\$newName.Infra.Data\EntitiesConfiguration\CategoryConfiguration.cs",
    "$path\$newName.Infra.Data\EntitiesConfiguration\ProductConfiguration.cs",
    "$path\$newName.Infra.Data\Identity\ApplicationUser.cs",
    "$path\$newName.Infra.Data\Identity\AuthenticateService.cs",
    "$path\$newName.Infra.Data\Identity\SeedUserRoleInitial.cs",
    "$path\$newName.Infra.Data\Migrations\20240212004725_Inicial.cs"
    "$path\$newName.Infra.Data\Migrations\20240212004725_Inicial.Designer.cs"
    "$path\$newName.Infra.Data\Migrations\20240212005328_SeedProducts.cs"
    "$path\$newName.Infra.Data\Migrations\20240212005328_SeedProducts.Designer.cs"
    "$path\$newName.Infra.Data\Migrations\20240221234706_AddIdentityTables.cs"
    "$path\$newName.Infra.Data\Migrations\20240221234706_AddIdentityTables.Designer.cs"
    "$path\$newName.Infra.Data\Migrations\ApplicationDbContextModelSnapshot.cs"
    "$path\$newName.Infra.Data\Repositories\CategoryRepository.cs",
    "$path\$newName.Infra.Data\Repositories\ProductRepository.cs",
    "$path\$newName.Infra.Data\Program.cs",

    # BoilerplateCleanArch.Infra.IoC
    "$path\$newName.Infra.IoC\DependencyInjection.cs",
    "$path\$newName.Infra.IoC\DependencyInjectionAPI.cs",
    "$path\$newName.Infra.IoC\DependencyInjectionJWT.cs",
    "$path\$newName.Infra.IoC\DependencyInjectionSwagger.cs",

    # BoilerplateCleanArch.WebUI
    "$path\$newName.WebUI\Controllers\AccountController.cs",
    "$path\$newName.WebUI\Controllers\CategoriesController.cs",
    "$path\$newName.WebUI\Controllers\HomeController.cs",
    "$path\$newName.WebUI\Controllers\ProductsController.cs",
    "$path\$newName.WebUI\ViewModel\LoginViewModel.cs",
    "$path\$newName.WebUI\ViewModel\RegisterViewModel.cs",
    "$path\$newName.WebUI\Views\Account\Login.cshtml",
    "$path\$newName.WebUI\Views\Account\Register.cshtml",
    "$path\$newName.WebUI\Views\Categories\Create.cshtml",
    "$path\$newName.WebUI\Views\Categories\Delete.cshtml",
    "$path\$newName.WebUI\Views\Categories\Details.cshtml",
    "$path\$newName.WebUI\Views\Categories\Edit.cshtml",
    "$path\$newName.WebUI\Views\Categories\Index.cshtml",
    "$path\$newName.WebUI\Views\Home\Index.cshtml",
    "$path\$newName.WebUI\Views\Home\Privacy.cshtml",
    "$path\$newName.WebUI\Views\Products\Create.cshtml",
    "$path\$newName.WebUI\Views\Products\Delete.cshtml",
    "$path\$newName.WebUI\Views\Products\Details.cshtml",
    "$path\$newName.WebUI\Views\Products\Edit.cshtml",
    "$path\$newName.WebUI\Views\Products\Index.cshtml",
    "$path\$newName.WebUI\Views\Shared\_Layout.cshtml",
    "$path\$newName.WebUI\Views\Shared\_LoginPartial.cshtml",
    "$path\$newName.WebUI\Views\Shared\_ValidationScriptsPartial.cshtml",
    "$path\$newName.WebUI\Views\_ViewImports.cshtml",
    "$path\$newName.WebUI\Views\_ViewStart.cshtml",
    "$path\$newName.WebUI\Program.cs",
    "$path\$newName.WebUI\Startup.cs"
)

foreach ($filePath in $arquivosClass) {
    $content = Get-Content -Path $filePath
    $novoConteudo = $content -replace $oldName, $newName
    $novoConteudo | Set-Content -Path $filePath
}
