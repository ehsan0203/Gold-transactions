import { Component } from '@angular/core';
import { Gem } from '../models/gem';
import { GemsService } from '../services/gems.service';

@Component({
  selector: 'app-gems',
  templateUrl: './gems.component.html',
  styleUrls: ['./gems.component.css']
})
export class GemsComponent {
  gems: Gem[] = []
  constructor(private gemService: GemsService) {

  }
  ngOnInit() {
    this.gemService.getgems().subscribe({
      next: (response: Gem[]) => { this.gems = response },
      error: (error: any) => { console.log(error) },
      complete: () => { }
    })
  }
}
