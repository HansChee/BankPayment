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

    initPayment() {
        let tokens = document.getElementsByName('__RequestVerificationToken');
        let token: string | null = null;
        if (tokens.length > 0) {
            token = tokens.item(0).getAttribute('value');
        }
        this.paymentInfo = {
            bsb: this.formGroup.controls['bsb'].value as string,
            accountName: this.formGroup.controls['accountName'].value as string,
            accountNumber: this.formGroup.controls['accountNumber'].value as string,
            reference: this.formGroup.controls['reference'].value as string,
            amount: this.formGroup.controls['amount'].value as number,
            __RequestVerificationToken: token == null ? '' : token.toString()
        }
    }

    constructor(private formBuilder: FormBuilder
        , private commonService: CommonService) {
        this.formGroup = formBuilder.group({
            'bsb': [null, Validators.compose([
                Validators.required
                , Validators.pattern(/^\d{3}-\d{3}$/)
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
            ])]
        });
    }

    paymentInfo: IPaymentInfo;

    submitPayment = () => {
        if (this.formGroup.valid) {
            this.initPayment();
            //console.log(this.paymentInfo);
            this.commonService.postForm('./api/WhatEver/SavePayment'
                , this.paymentInfo
                , (val) => {
                    let res = val.json() as IPaymentSaveResponse;
                    if (res.success) {
                        console.log((res.errors as string[])[0]);
                    } else {
                        console.error(res.errors);
                    }
                });
        }
    }
}
interface IPaymentInfo {
    bsb?: string;
    accountNumber?: string;
    accountName?: string;
    reference?: string;
    amount?: number;
    __RequestVerificationToken?: string;
}
interface IJsonResponse {
    success?: boolean;
    errors?: string[];
}
interface IPaymentSaveResponse extends IJsonResponse {
    extraMessage?: string;
}
