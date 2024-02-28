$path = "D:\Projetos\Pessoal\teste" 
Get-ChildItem $path  -Recurse | Where-Object { $_.Name.Contains('BoilerplateCleanArch') } | Rename-Item -NewName { $_.Name -replace 'BoilerplateCleanArch', 'NovoNome' }

# Caminho do arquivo de texto
# Lista de arquivos
$arquivos = @(
    "D:\Projetos\Pessoal\Teste\NovoNome.sln",
    "D:\Projetos\Pessoal\teste\NovoNome.API\NovoNome.API.csproj",
    "D:\Projetos\Pessoal\teste\NovoNome.Application\NovoNome.Application.csproj",
    "D:\Projetos\Pessoal\teste\NovoNome.Domain\NovoNome.Domain.csproj",
    "D:\Projetos\Pessoal\teste\NovoNome.Domain.Tests\NovoNome.Domain.Tests.csproj",
    "D:\Projetos\Pessoal\teste\NovoNome.Infra.IoC\NovoNome.Infra.IoC.csproj",
    "D:\Projetos\Pessoal\teste\NovoNome.Infra.Data\NovoNome.Infra.Data.csproj",
    "D:\Projetos\Pessoal\teste\NovoNome.WebUI\NovoNome.WebUI.csproj",
    "D:\Projetos\Pessoal\teste\NovoNome.Infra.IoC\DependencyInjectionAPI.cs",
    "D:\Projetos\Pessoal\teste\NovoNome.Infra.IoC\DependencyInjection.cs"
)

foreach ($filePath in $arquivos) {

    $content = Get-Content -Path $filePath


    $novoConteudo = $content -replace "BoilerplateCleanArch", "NovoNome"


    $novoConteudo | Set-Content -Path $filePath
}
