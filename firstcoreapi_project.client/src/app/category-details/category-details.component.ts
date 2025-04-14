import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UrlserviceService } from '../urlservice.service';

@Component({
  selector: 'app-category-details',
  standalone: false,
  templateUrl: './category-details.component.html',
  styleUrl: './category-details.component.css'
})
export class CategoryDetailsComponent {

  Category : any
  constructor(private route: ActivatedRoute, private _url: UrlserviceService) { }
  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this._url.getById(+id).subscribe((data: any) => {
        this.Category = data;
      });
    }
  }
}
