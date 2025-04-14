import { Component } from '@angular/core';
import { UrlserviceService } from '../urlservice.service';

@Component({
  selector: 'app-category',
  standalone: false,
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent {
  categories: any[] = [];
  editModeId: number | null = null;
  updatedCategory: any = { CategoryName: '' };

  constructor(private _url: UrlserviceService) { }

  ngOnInit(): void {
    this.getAllCategories();
  }

  getAllCategories() {
    this._url.getall().subscribe((data: any) => {
      this.categories = data;
    });
  }

  addCategory(data: any) {
    const formData = new FormData();
    formData.append("CategoryName", data.CategoryName);

    this._url.addcategory(formData).subscribe(() => {
      alert("Category added");
      this.getAllCategories();
    });
  }

  deleteCategory(id: number) {
    if (confirm("Are you sure you want to delete this category?")) {
      this._url.deletecategory(id).subscribe(() => {
        alert("Deleted");
        this.getAllCategories();
      });
    }
  }

  startEdit(cat: any) {
    this.editModeId = cat.categoryId;
    this.updatedCategory = { CategoryName: cat.categoryName };
  }

  cancelEdit() {
    this.editModeId = null;
    this.updatedCategory = { CategoryName: '' };
  }

  updateCategory(id: number) {
    const formData = new FormData();
    formData.append("CategoryId", id.toString());
    formData.append("CategoryName", this.updatedCategory.CategoryName);

    this._url.updatecategory(id, formData).subscribe(() => {
      alert("Category updated");
      this.getAllCategories();
      this.cancelEdit();
    });
  }

  getCategoryDetails(id: number) {
    this._url.getById(id).subscribe((data: any) => {
      console.log("Category details:", data);
      alert(`ID: ${data.categoryId} - Name: ${data.categoryName}`);
    });
  }

}
