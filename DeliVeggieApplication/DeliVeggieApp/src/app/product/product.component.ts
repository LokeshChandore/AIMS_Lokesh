import { Component, OnInit } from '@angular/core';
import { ApplicationService } from '../services/application.service';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [RouterOutlet, CommonModule, RouterModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit {
 
  products?: any[];
  constructor(private service: ApplicationService) {}

  ngOnInit(): void {
    this.service.getProduct().subscribe((response:any[]) => {
      this.products = response;
    });

  }
}
