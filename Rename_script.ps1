$oldName = "BoilerplateCleanArch"
$path = "D:\Projetos\Pessoal\$oldName" 
$newName = "NovoNome"
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

foreach ($filePath in $arquivos) {
    $content = Get-Content -Path $filePath
    $novoConteudo = $content -replace "$newName", "$newName"
    $novoConteudo | Set-Content -Path $filePath
}

$arquivosClass = @(
    #$newName\$newName.API
    "$path\$newName\$newName.API\Controllers\CategoriesController.cs",
    "$path\$newName\$newName.API\Controllers\ProductsController.cs",
    "$path\$newName\$newName.API\Controllers\TokenController.cs",
    "$path\$newName\$newName.API\DTO\LoginDTO.cs",
    "$path\$newName\$newName.API\DTO\RegisterDTO.cs",
    "$path\$newName\$newName.API\DTO\UserTokenDTO.cs",
    "$path\$newName\$newName.API\Program.cs",
    "$path\$newName\$newName.API\Startup.cs",
    
    #$newName\$newName.Application
    "$path\$newName\$newName.Application\DTOS\CategoryDTO.cs",
    "$path\$newName\$newName.Application\DTOS\ProductDTO.cs",
    "$path\$newName\$newName.Application\Interfaces\ICategoryService.cs",
    "$path\$newName\$newName.Application\Interfaces\IProductService.cs",
    "$path\$newName\$newName.Application\Mappings\DomainToDTOMappingProfile.cs",
    "$path\$newName\$newName.Application\Mappings\DTOtoCommandMappingProfile.cs",
    "$path\$newName\$newName.Application\Products\Commands\ProductCommand.cs",
    "$path\$newName\$newName.Application\Products\Commands\ProductCreateCommand.cs",
    "$path\$newName\$newName.Application\Products\Commands\ProductRemoveCommand.cs",
    "$path\$newName\$newName.Application\Products\Commands\ProductUpdateCommand.cs",
    "$path\$newName\$newName.Application\Products\Handlers\GetProductByIdQueryHandler.cs",
    "$path\$newName\$newName.Application\Products\Handlers\GetProductsQueryHandler.cs",
    "$path\$newName\$newName.Application\Products\Handlers\ProductCreateCommandHandler.cs",
    "$path\$newName\$newName.Application\Products\Handlers\ProductRemoveCommandHandler.cs",
    "$path\$newName\$newName.Application\Products\Handlers\ProductUpdateCommandHandler.cs",
    "$path\$newName\$newName.Application\Products\Queries\GetProductsByIdQuery.cs",
    "$path\$newName\$newName.Application\Products\Queries\GetProductsQueries.cs",
    "$path\$newName\$newName.Application\Services\CategoryService.cs",
    "$path\$newName\$newName.Application\Services\ProductService.cs",

    #$newName\$newName.Domain
    "$path\$newName\$newName.Domain\Account\IAuthenticate.cs",
    "$path\$newName\$newName.Domain\Account\ISeedUserRoleInitial.cs",
    "$path\$newName\$newName.Domain\Account\IAuthenticate.cs",
    "$path\$newName\$newName.Domain\Account\ISeedUserRoleInitial.cs",
    "$path\$newName\$newName.Domain\Interfaces\ICategoryRepository.cs",
    "$path\$newName\$newName.Domain\Interfaces\IProductRepository.cs",
    "$path\$newName\$newName.Domain\Validation\DomainExceptionValidation.cs",

    #$newName\$newName.Domain.Tests
    "$path\$newName\$newName.Domain.Tests\CategoryUnitTest1.cs",
    "$path\$newName\$newName.Domain.Tests\ProductUnitTest1.cs",

    #$newName\$newName.Infra.Data
    "$path\$newName\$newName.Infra.Data\Context\ApplicationDbContext.cs",
    "$path\$newName\$newName.Infra.Data\EntitiesConfiguration\CategoryConfiguration.cs",
    "$path\$newName\$newName.Infra.Data\EntitiesConfiguration\ProductConfiguration.cs",
    "$path\$newName\$newName.Infra.Data\Identity\ApplicationUser.cs",
    "$path\$newName\$newName.Infra.Data\Identity\AuthenticateService.cs",
    "$path\$newName\$newName.Infra.Data\Identity\SeedUserRoleInitial.cs",
    "$path\$newName\$newName.Infra.Data\Repositories\CategoryRepository.cs",
    "$path\$newName\$newName.Infra.Data\Repositories\ProductRepository.cs",
    "$path\$newName\$newName.Infra.Data\Program.cs",
    "$path\$newName\$newName.Infra.IoC\DependencyInjection.cs",
    "$path\$newName\$newName.Infra.IoC\DependencyInjectionAPI.cs",
    "$path\$newName\$newName.Infra.IoC\DependencyInjectionJWT.cs",
    "$path\$newName\$newName.Infra.IoC\DependencyInjectionSwagger.cs",

    #$newName.WebUI\Controllers
    "$path\$newName\$newName.WebUI\Controllers\AccountController.cs",
    "$path\$newName\$newName.WebUI\Controllers\CategoriesController.cs",
    "$path\$newName\$newName.WebUI\Controllers\HomeController.cs",
    "$path\$newName\$newName.WebUI\Controllers\ProductsController.cs",
    "$path\$newName\$newName.WebUI\ViewModel\LoginViewModel.cs",
    "$path\$newName\$newName.WebUI\ViewModel\RegisterViewModel.cs",
    "$path\$newName\$newName.WebUI\Views\Account\Login.cshtml",
    "$path\$newName\$newName.WebUI\Views\Account\Register.cshtml",
    "$path\$newName\$newName.WebUI\Views\Categories\Create.cshtml",
    "$path\$newName\$newName.WebUI\Views\Categories\Delete.cshtml",
    "$path\$newName\$newName.WebUI\Views\Categories\Details.cshtml",
    "$path\$newName\$newName.WebUI\Views\Categories\Edit.cshtml",
    "$path\$newName\$newName.WebUI\Views\Categories\Index.cshtml",
    "$path\$newName\$newName.WebUI\Views\Home\Index.cshtml",
    "$path\$newName\$newName.WebUI\Views\Home\Privacy.cshtml",
    "$path\$newName\$newName.WebUI\Views\Products\Create.cshtml",
    "$path\$newName\$newName.WebUI\Views\Products\Delete.cshtml",
    "$path\$newName\$newName.WebUI\Views\Products\Details.cshtml",
    "$path\$newName\$newName.WebUI\Views\Products\Edit.cshtml",
    "$path\$newName\$newName.WebUI\Views\Products\Index.cshtml",
    "$path\$newName\$newName.WebUI\Views\Shared\_Layout.cshtml",
    "$path\$newName\$newName.WebUI\Views\Shared\_LoginPartial.cshtml",
    "$path\$newName\$newName.WebUI\Views\Shared\_ValidationScriptsPartial.cshtml",
    "$path\$newName\$newName.WebUI\Views\_ViewImports.cshtml",
    "$path\$newName\$newName.WebUI\Views\_ViewStart.cshtml",
    "$path\$newName\$newName.WebUI\Program.cs",
    "$path\$newName\$newName.WebUI\Startup.cs"
)

foreach ($filePath in $arquivosClass) {
    $content = Get-Content -Path $filePath
    $novoConteudo = $content -replace "$newName", "$newName"
    $novoConteudo | Set-Content -Path $filePath
}
