using BoilerplateCleanArch.Application.DTOS.Product;
using BoilerplateCleanArch.Application.Interfaces.ICategoryService;
using BoilerplateCleanArch.Application.Interfaces.IProductService;
using BoilerplateCleanArch.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Threading.Tasks;

namespace BoilerplateCleanArch.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productsService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductsController(IProductService productsService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _productsService = productsService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productsService.GetProducts();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDto)
        {
            if (ModelState.IsValid)
            {
                await _productsService.Add(productDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            }
            return View(productDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var productDTO = await _productsService.GetById(id.Value);

            if (productDTO == null) return NotFound();

            var categories = await _categoryService.GetCategories();

            ViewBag.CategoryId = new SelectList(await _categoryService.GetCategories(), "Id", "Name");

            return View(productDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productsService.Update(productDTO);
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(productDTO);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var productDTO = await _productsService.GetById(id.Value);

            if (productDTO == null) return NotFound();

            return View(productDTO);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productsService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var productDTO = await _productsService.GetById(id.Value);

            if (productDTO == null) return NotFound();

            var wwwroot = _webHostEnvironment.WebRootPath;
            var image = Path.Combine(wwwroot, "images\\" + productDTO.Image);
            var exists = System.IO.File.Exists(image);
            ViewBag.ImageExist = exists;

            return View(productDTO);
        }
    }
}
