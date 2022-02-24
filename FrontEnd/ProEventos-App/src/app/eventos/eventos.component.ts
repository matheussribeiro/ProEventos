import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

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

  constructor(private eventoService : EventoService) { }

  public ngOnInit(): void {
    this.getEventos();
  }

  public getEventos() : void {
    this.eventoService.getEventos().subscribe(
      (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFilters = this.eventos
      },
      error => console.log(error)
    );
  }


}
