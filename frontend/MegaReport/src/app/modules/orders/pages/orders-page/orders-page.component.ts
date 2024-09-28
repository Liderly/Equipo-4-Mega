import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OrdersService } from '../../services/orders.service';

@Component({
  selector: 'app-orders-page',
  templateUrl: './orders-page.component.html',
  styleUrls: ['./orders-page.component.css']
})
export class OrdersPageComponent implements OnInit, OnDestroy{
  id:number = 0;
  listOrders$: Array<any> = [];

  constructor(private route:ActivatedRoute, private orderService: OrdersService){}

  ngOnInit(){
    this.id = Number(this.route.snapshot.queryParams['id']);
    this.orderService.getOrders$(this.id)
    .subscribe(resp => {
      this.listOrders$ = resp
      console.log(this.listOrders$)
    })
    
  }

  ngOnDestroy(): void {
    
  }
}
