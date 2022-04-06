import { Component, OnInit, TemplateRef } from '@angular/core';
import { RouteConfigLoadEnd, Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from 'src/app/models/Evento';
import { EventoService } from 'src/app/services/evento.service';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {

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
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
  ) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

  public getEventos() : void {
    this.eventoService.getEventos().subscribe({
      next:(eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFilters = this.eventos;
      },
      error:(error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os eventos','Error!')
      },
      complete: () => this.spinner.hide()
    });
  }


  openModalDelete(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('O Evento foi deletado com sucesso! ', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }

  detalheEvento(id: number): void {
    this.router.navigate([`eventos/detalhe/${id}`]);
  }
}
