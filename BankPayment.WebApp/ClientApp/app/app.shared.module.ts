import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { PaymentComponent } from './components/payment/payment.component';
import { CommonService } from './shared/common.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        PaymentComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'payment', component: PaymentComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        CommonService
    ]
})
export class AppModuleShared {
}
