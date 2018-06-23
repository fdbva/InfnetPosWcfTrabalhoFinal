using System;
using System.Linq;
using System.Threading.Tasks;
using AdminUiQuestionWcfService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Evaluation.AdminUi.Controllers
{
    public class QuestionController : Controller
    {
        public virtual async Task<IActionResult> Index()
        {
            var adminUiQuestionServiceClient = new AdminUiQuestionServiceClient();
            await adminUiQuestionServiceClient.OpenAsync();
            var result = await adminUiQuestionServiceClient.GetAllAsync();
            await adminUiQuestionServiceClient.CloseAsync();
            return View(result);
        }

        public virtual async Task<IActionResult> Details(Guid? id)
        {
            return await GetEntityViewModel(id);
        }

        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Create(QuestionViewModel entityViewModel)
        {
            var adminUiQuestionServiceClient = new AdminUiQuestionServiceClient();
            await adminUiQuestionServiceClient.OpenAsync();
            if (ModelState.IsValid)
            {
                entityViewModel.Id = Guid.NewGuid();
                await adminUiQuestionServiceClient.AddAsync(entityViewModel);
                await adminUiQuestionServiceClient.CloseAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(entityViewModel);
        }

        public virtual async Task<IActionResult> Edit(Guid? id)
        {
            return await GetEntityViewModel(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> Edit(Guid id, QuestionViewModel entityViewModel)
        {
            if (id != entityViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var adminUiQuestionServiceClient = new AdminUiQuestionServiceClient();
                try
                {
                    await adminUiQuestionServiceClient.OpenAsync();
                    await adminUiQuestionServiceClient.UpdateAsync(entityViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await EntityViewModelExists(entityViewModel.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                finally
                {
                    await adminUiQuestionServiceClient.CloseAsync();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(entityViewModel);
        }

        public virtual async Task<IActionResult> Delete(Guid? id)
        {
            return await GetEntityViewModel(id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var adminUiQuestionServiceClient = new AdminUiQuestionServiceClient();
            await adminUiQuestionServiceClient.OpenAsync();
            await adminUiQuestionServiceClient.RemoveAsync(id);
            await adminUiQuestionServiceClient.CloseAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<IActionResult> GetEntityViewModel(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adminUiQuestionServiceClient = new AdminUiQuestionServiceClient();
            await adminUiQuestionServiceClient.OpenAsync();
            var entityViewModel = await adminUiQuestionServiceClient.FindAsync(id.Value);
            await adminUiQuestionServiceClient.CloseAsync();
            if (entityViewModel == null)
            {
                return NotFound();
            }

            return View(entityViewModel);
        }

        private async Task<bool> EntityViewModelExists(Guid id)
        {
            var adminUiQuestionServiceClient = new AdminUiQuestionServiceClient();
            await adminUiQuestionServiceClient.OpenAsync();
            var result = (await adminUiQuestionServiceClient.GetAllAsNoTrackingAsync()).Any(e => e.Id == id);
            await adminUiQuestionServiceClient.CloseAsync();
            return result;
        }
    }
}