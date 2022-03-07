import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  modalRef?: BsModalRef;

  public eventos: Evento[] = [];
  public eventosFilters: Evento[] = []
  marginImg = 2;
  isCollapsed = true;
  private _filterList = '';

  public get filterList()
  {
    return this._filterList;
  }

  public set filterList(value: string)
  {
    this._filterList = value;
    this.eventosFilters = this.filterList ? this.filterEvents(this.filterList) : this.eventos
  }

  public filterEvents(filterTo: string): Evento[]
  {
    filterTo = filterTo.toLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLowerCase().indexOf(filterTo) !== -1 ||
      evento.local.toLowerCase().indexOf(filterTo) !== -1
    )
  }

  constructor(
    private eventoService : EventoService,
    private modalService: BsModalService
  ) { }

  public ngOnInit(): void {
    this.getEventos();
  }

  public getEventos() : void {
    this.eventoService.getEventos().subscribe({
      next:(eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFilters = this.eventos;
      },
      error:(error: any) => console.log(error)
    });
  }


  openModalDelete(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
