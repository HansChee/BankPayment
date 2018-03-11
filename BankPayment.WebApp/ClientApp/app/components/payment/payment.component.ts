import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommonService } from '../../shared/common.service';
import { AbstractControl } from '@angular/forms/src/model';

@Component({
    selector: 'payment'
    , templateUrl: './payment.component.html'
    , styleUrls: ['./payment.component.css']
})
export class PaymentComponent {
    formGroup: FormGroup;

    MessageStyles: Map<boolean, string> = new Map<boolean, string>();

    messageStyle?: string;

    private _returnMessage: string = '';

    set returnMessage(msg: string) {
        this._returnMessage = msg;
        setTimeout(() => {            
            this._returnMessage = '';
            console.log('Return message cleared');
        }, 2000);
    }

    get returnMessage(): string {
        return this._returnMessage;
    }

    initPayment(clearFrom: boolean) {
        let controls = this.formGroup.controls as { [key: string]: AbstractControl };
        console.log('controls status: ');
        console.log(controls);

        if (!clearFrom) {
            console.log('Get form values from controls');
            let tokens = document.getElementsByName('__RequestVerificationToken');
            let token: string | null = null;
            if (tokens.length > 0) {
                token = tokens.item(0).getAttribute('value');
            }
            console.log('Got anti forgety token: ', token);

            this.paymentInfo = {
                bsb: controls['bsb'].value as string,
                accountName: controls['accountName'].value as string,
                accountNumber: controls['accountNumber'].value as string,
                reference: controls['reference'].value as string,
                amount: controls['amount'].value as number,
                __RequestVerificationToken: token == null ? '' : token.toString()
            }
            console.log('Got form values from controls: ');
            console.log(this.paymentInfo);
        } else {
            console.log('Clear form and model');
            this.paymentInfo = {};
            this.formGroup.reset();
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
                , Validators.pattern(/^\d+$/)
            ])],
            'accountName': [null, Validators.required],
            'reference': [null, Validators.maxLength(20)],
            'amount': [null, Validators.compose([
                Validators.required
                , Validators.min(1)
            ])]
        });
        console.log('Form group initialized');

        this.MessageStyles.set(true, 'payment-success');
        this.MessageStyles.set(false, 'payment-warning');
        console.log('Message style initialized');
    }

    paymentInfo: IPaymentInfo;

    submitPayment = () => {
        if (this.formGroup.valid) {
            console.log('Form group is valid');

            this.initPayment(false);

            this.commonService.postForm('./api/WhatEver/SavePayment'
                , this.paymentInfo
                , (val) => {
                    let res = val.json() as IPaymentSaveResponse;
                    console.log('Response: ');
                    console.log(res);
                    this.returnMessage = (res.errors as string[])[0];
                    this.messageStyle = this.MessageStyles.get(res.success);
                    if (res.success) {
                        console.log('Got response: ');
                        console.log((res.errors as string[])[0]);

                        this.initPayment(true);
                    } else {
                        console.error(res.errors);
                        // todo
                    }
                }
                , (err) => {
                    console.error(err);
                    // todo
                });
        }
    }

}
interface IAntiForgery {
    __RequestVerificationToken?: string;
}
interface IPaymentInfo extends IAntiForgery {
    bsb?: string;
    accountNumber?: string;
    accountName?: string;
    reference?: string;
    amount?: number;
}
interface IJsonResponse {
    success: boolean;
    errors?: string[];
}
interface IPaymentSaveResponse extends IJsonResponse {
    extraMessage?: string;
}
