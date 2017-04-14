using System.Collections.Generic;
using static LbkRegister.Domain.CompetitionClass;

namespace LbkRegister.ViewModels {
    class CategoryViewModel {
        public CategoryViewModel(Categories category) {
            Category = category;
            Name = category.ToName();
        }

        public Categories Category { get; }
        public string Name { get; }

        public static IEnumerable<CategoryViewModel> GetList() =>
            new List<CategoryViewModel> {
                new CategoryViewModel(Categories.SixMonths),
                new CategoryViewModel(Categories.NineMonths),
                new CategoryViewModel(Categories.FifteenMonths),
                new CategoryViewModel(Categories.EightYears)
            };
    }
}
