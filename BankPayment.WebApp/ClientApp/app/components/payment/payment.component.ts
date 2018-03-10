import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommonService } from '../../shared/common.service';

@Component({
    selector: 'payment'
    , templateUrl: './payment.component.html'
    , styleUrls: ['./payment.component.css']
})
export class PaymentComponent {
    formGroup: FormGroup;

    constructor(private formBuilder: FormBuilder
        , private commonService: CommonService) {
        this.formGroup = formBuilder.group({
            'bsb': [null, Validators.compose([
                Validators.required
                , Validators.pattern(/\d{3}-\d{3}/)
            ])],
            'accountNumber': [null, Validators.compose([
                Validators.required
                , Validators.pattern(/\d+/)
            ])],
            'accountName': [null, Validators.required],
            'reference': [null, Validators.maxLength(20)],
            'amount': [null, Validators.compose([
                Validators.required
                , Validators.min(1)
            ])],
            'validate': ''
        });
    }

    paymentInfo: IPaymentInfo = {};

    submitPayment = () => {
        if (this.formGroup.valid) {
            this.paymentInfo = {
                BSB: this.formGroup.controls['bsb'].value as string,
                AccountName: this.formGroup.controls['accountName'].value as string,
                AccountNumber: this.formGroup.controls['accountNumber'].value as string,
                Reference: this.formGroup.controls['reference'].value as string,
                Amount: this.formGroup.controls['amount'].value as number
            }
            console.log(this.paymentInfo);
            this.commonService.postJson('./api/WhatEver/SavePayment'
                , this.paymentInfo
                , (val) => {
                    let res = val.json();
                    console.log(res);
                });
        }
    }
}
interface IPaymentInfo {
    BSB?: string;
    AccountNumber?: string;
    AccountName?: string;
    Reference?: string;
    Amount?: number
}

