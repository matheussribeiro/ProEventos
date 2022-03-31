import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss']
})
export class TitleComponent implements OnInit {
  @Input() titulo = '';
  @Input() iconClass = 'fa fa-user';
  @Input() subtitulo = 'Desde 2021';
  @Input() mostraBotao = false;

  constructor() { }

  ngOnInit(): void {
  }

}
