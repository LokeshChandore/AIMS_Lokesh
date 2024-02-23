import { Component, OnInit } from '@angular/core';
import { ApplicationService } from '../services/application.service'
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './product-detail.component.html',
  styleUrl: './product-detail.component.css'
})
export class ProductDetailComponent implements OnInit {

  productDetail?: any;
  constructor(private service: ApplicationService, private activateRoute: ActivatedRoute){}

  ngOnInit(): void {
   var  id = this.activateRoute.snapshot.queryParamMap.get('id');
    this.service.getProductById(id).subscribe((response:any) => {
      this.productDetail = response;
    });
  }
}
