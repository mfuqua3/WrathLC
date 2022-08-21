import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RaidPlanningComponent } from './raid-planning.component';
import { EncounterSelectComponent } from './encounter-select/encounter-select.component';



@NgModule({
  declarations: [
    RaidPlanningComponent,
    EncounterSelectComponent
  ],
  imports: [
    CommonModule
  ]
})
export class RaidPlanningModule {
}
