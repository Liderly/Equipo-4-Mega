import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { OrdersService } from '../../services/orders.service';
import jsPDF from 'jspdf';
import 'jspdf-autotable';
import * as XLSX from 'xlsx';

@Component({
  selector: 'app-orders-page',
  templateUrl: './orders-page.component.html',
  styleUrls: ['./orders-page.component.css']
})
export class OrdersPageComponent implements OnInit, OnDestroy{
  id:number = 0;
  totalAmount$: Array<any> = [];
  technicianInfo$: Array<any> = [];
  ordersInProgress$: any[] = [];
  ordersCompleted$: any[] = [];
  ordersPending$: any[] = [];
  ordersCanceled$: any[] = [];

  constructor(private route:ActivatedRoute, private orderService: OrdersService){}

  ngOnInit() {
    this.id = Number(this.route.snapshot.queryParams['id']);
  
    this.orderService.getOrders$(this.id).subscribe(resp => {
      if (resp && resp.length > 0) {
        this.ordersInProgress$ = resp.filter((order: any) => order.EstatusOrdenTrabajo === 'En progreso');
        this.ordersCompleted$ = resp.filter((order: any) => order.EstatusOrdenTrabajo === 'Finalizado');
        this.ordersPending$ = resp.filter((order: any) => order.EstatusOrdenTrabajo === 'En espera');
        this.ordersCanceled$ = resp.filter((order: any) => order.EstatusOrdenTrabajo === 'Cancelado');
        
        console.log(this.ordersCompleted$);

        const firstOrder = resp[0];
        this.technicianInfo$ = [
          firstOrder.NumeroEmpleado,
          firstOrder.Nombres,
          firstOrder.ApellidoPTecnico,
          firstOrder.ApellidoMTecnico,
          firstOrder.NombreCuadrilla
        ];
      }
    });

    this.orderService.getTotalAmount$(this.id).subscribe(resp => {
      this.totalAmount$ = resp
    });

    console.log("hola" + this.totalAmount$);
  }

  generatePDF() {
    const doc = new jsPDF();
  
    const columns = [
      { header: 'N. orden de trabajo', dataKey: 'IdOrdenTrabajo' },
      { header: 'Trabajo', dataKey: 'NombreTrabajo' },
      { header: 'Descripción', dataKey: 'DescripcionTrabajo' },
      { header: 'Inicio', dataKey: 'FechaInicio' },
      { header: 'Fin', dataKey: 'FechaFin' },
      { header: 'Puntos', dataKey: 'Nombres' }
    ];

    const nombreTecnico = `${this.ordersCompleted$[0]?.Nombres} ${this.ordersCompleted$[0]?.ApellidoPTecnico} ${this.ordersCompleted$[0]?.ApellidoMTecnico}`;
    const rows = this.ordersCompleted$.map(order => ({
      IdOrdenTrabajo: order.IdOrdenTrabajo,
      NombreTrabajo: order.NombreTrabajo,
      DescripcionTrabajo: order.DescripcionTrabajo,
      FechaInicio: new Date(order.TiempoRegistroOrdenTrabajo).toLocaleDateString('es-ES', {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit'
      }),
      FechaFin: order.TiempoFinalizadoOrdenTrabajo ? 
          new Date(order.TiempoFinalizadoOrdenTrabajo).toLocaleDateString('es-ES', {
            year: 'numeric',
            month: '2-digit',
            day: '2-digit'
          }) : 'N/A',
      Nombres: `${order.Nombres} ${order.ApellidoPTecnico} ${order.ApellidoMTecnico}`
    }));
  
    doc.setFontSize(14);
    doc.text('Reporte de órdenes de trabajos finalizadas', 10, 15);
    doc.setFontSize(12);
    doc.text(`${nombreTecnico}`, 10, 20);
    
    (doc as any).autoTable({
      head: [columns.map(col => col.header)],  
      body: rows.map(row => columns.map(col => row[col.dataKey as keyof typeof row])), 
      
      theme: 'grid',  
      styles: {
        fontSize: 10,
        cellPadding: 4,
        textColor: [1, 45, 80],  
      },
      headStyles: {
        fillColor: [1, 45, 80],  
        textColor: [255, 255, 255],  
        fontStyle: 'bold',  
        halign: 'center', 
        valign: 'middle',
      },
      bodyStyles: {
        fillColor: [245, 245, 245], 
      },
      alternateRowStyles: {
        fillColor: [255, 255, 255], 
      },
      margin: { top: 30, right: 10, bottom: 30, left: 10 },  
      columnStyles: {
        0: { halign: 'center', valign: 'middle' },  
        3: { halign: 'center', valign: 'middle' },  
        4: { halign: 'center', valign: 'middle' },  
        5: { halign: 'center', valign: 'middle' }, 
      }
    });
  
    doc.save('ordenes-completadas.pdf');
  }  

  generateExcel() {
    const orders = this.ordersCompleted$;
  
    const workbook = XLSX.utils.book_new();
  
    const worksheet = XLSX.utils.json_to_sheet(orders.map(order => ({
      'N. orden de trabajo': order.IdOrdenTrabajo,
      'Trabajo': order.NombreTrabajo,
      'Descripción': order.DescripcionTrabajo,
      'Inicio': new Date(order.TiempoRegistroOrdenTrabajo).toLocaleDateString('es-ES'), // Fecha corta
      'Fin': order.TiempoFinalizadoOrdenTrabajo ? 
      new Date(order.TiempoFinalizadoOrdenTrabajo).toLocaleDateString('es-ES') : 'N/A', // Fecha corta
      'Puntos': order.EstatusOrdenTrabajo,
    
    })));
  
    XLSX.utils.book_append_sheet(workbook, worksheet, 'Órdenes Completadas');
  
    XLSX.writeFile(workbook, 'ordenes_completadas.xlsx');
  }
  
  ngOnDestroy(): void {
    
  }
}
