import { Evento } from "./Evento";

export interface RedeSocial {
   id: number;
   nome: string;
   url: string;
   evento: Evento;
   palestranteId?: number;
}
