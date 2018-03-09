import { Component } from '@angular/core';
import { CommonService } from '../../shared/common.service';

@Component({
    selector: 'payment'
    , templateUrl: './payment.component.html'
    , styleUrls: ['./payment.component.css']
})
export class PaymentComponent {
    constructor(private commonService: CommonService) { }

    paymentInfo: IPaymentInfo = {};

    //validatePaymentInfo = (): boolean => {

    //}

    submitPayment = () => {
        console.log(this.paymentInfo);
        this.commonService.postJson('./api/WhatEver/SavePayment'
            , this.paymentInfo
            , (val) => {
                let res = val.json();
                console.log(res);
            });
    }
}
interface IPaymentInfo {
    BSB?: string;
    AccountNumber?: number;
    AccountName?: string;
    Reference?: string;
    Amount?: number
}

