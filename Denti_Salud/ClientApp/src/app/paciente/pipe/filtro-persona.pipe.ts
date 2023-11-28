import { Pipe, PipeTransform } from '@angular/core'
import { Paciente } from '../../models/Paciente'

@Pipe({
  name: 'filtroPersona',
})
export class FiltroPersonaPipe implements PipeTransform {
  transform(cliente: Paciente[], searchText: string): any {
    if (searchText == null) return cliente;
    return cliente.filter(
      (p) => p.nombre.toLowerCase().indexOf(searchText.toLowerCase()) !== -1,
    )
  }
}
