import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFilters: any = []
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

  filterEvents(filterTo: string): any
  {
    filterTo = filterTo.toLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLowerCase().indexOf(filterTo) !== -1 ||
      evento.local.toLowerCase().indexOf(filterTo) !== -1
    )
  }

  constructor(private eventoService : EventoService) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos() : void {
    this.eventoService.getEventos().subscribe(
      response => {
        this.eventos = response;
        this.eventosFilters = this.eventos
      },
      error => console.log(error)
    );
  }


}
