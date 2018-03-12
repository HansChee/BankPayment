/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { PaymentComponent } from './payment.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonService } from '../../shared/common.service';
import { HttpModule } from '@angular/http';

let component: PaymentComponent;
let fixture: ComponentFixture<PaymentComponent>;

describe('payment component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [PaymentComponent],
            imports: [
                BrowserModule
                , FormsModule
                , ReactiveFormsModule
                , HttpModule],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
                , CommonService
            ]
        });
        fixture = TestBed.createComponent(PaymentComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});