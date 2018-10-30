import { MatButtonModule, MatCheckboxModule,MatRadioModule } from '@angular/material';
import { NgModule } from '@angular/core';

@NgModule({
    imports: [MatButtonModule, MatCheckboxModule,MatButtonModule],
    exports: [MatButtonModule, MatCheckboxModule,MatRadioModule],
})
export class MaterialModule { }