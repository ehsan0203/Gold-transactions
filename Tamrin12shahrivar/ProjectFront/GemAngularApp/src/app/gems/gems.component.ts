import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Gem } from '../models/gem';
import { GemsService } from '../services/gems.service';

@Component({
  selector: 'app-gems',
  templateUrl: './gems.component.html',
  styleUrls: ['./gems.component.css']
})
export class GemsComponent {
  gems: Gem[] = []
  postformgem: FormGroup;
  constructor(private gemService: GemsService) {
    this.postformgem = new FormGroup({
      data: new FormControl(null, [Validators.required]),
      weight: new FormControl(null, [Validators.required]),
      cutie: new FormControl(null, [Validators.required]),
      price: new FormControl(null, [Validators.required]),
      status: new FormControl(null, [Validators.required])

    })
  }
  ngOnInit() {
    this.gemService.getgems().subscribe({
      next: (response: Gem[]) => { this.gems = response },
      error: (error: any) => { console.log(error) },
      complete: () => { }
    })
  }

    public postGemSubmited() {
      this.gemService.postgems(this.postformgem.value).subscribe({
        next: (response: Gem) => {
          this.gems.push(new Gem(response.gemId, response.data, response.weight,
            response.cutie, response.price, response.status));
          this.postformgem.reset();

        },
        error: (error: any) => { console.log(error) },
        complete: () => { }
      });

    }
  }
