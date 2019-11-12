import { Injectable, Inject } from '@angular/core';
import { Http, Request, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { StyleMulti } from './styleMulti.model';
import { StyleMultiCategory } from './styleMultiCategory.model';
import { StyleDetail } from './styleDetail.model';
import { Cart } from './cart.model';
import { Order } from './order.model';
import { OrderSummary } from './orderSummary.model';
import { OrderDetail } from './orderDetail.model';
import { SkuQuantity } from './skuQuantity.model';
import { ORIGIN_URL } from '../../constants';

@Injectable()
export class RestDataSource {
    baseurl: string;

    constructor(private http: Http, @Inject(ORIGIN_URL) private originUrl:string) {
        this.baseurl = `${originUrl}/skishop/`;
    }

    getAllStyles(): Observable<StyleMulti[]> {
        return this.sendRequest(RequestMethod.Get, 'getAllStyle');
    }

    getPopularClearance(): Observable<StyleMulti[]> {
        return this.sendRequest(RequestMethod.Get, 'getPopularClearance');
    }

    getCategories(): Observable<string[]> {
        return this.sendRequest(RequestMethod.Get, 'getCategories');
    }

    getStylesByCategory(category: string): Observable<StyleMultiCategory[]> {
        return this.sendRequest(RequestMethod.Get, `getByCategory/${category}`);
    }

    getStyleDetail(styleNo: string): Observable<StyleDetail> {
        return this.sendRequest(RequestMethod.Get, `getStyleDetail/${styleNo}`);
    }

    saveOrder(order: Order): Observable<Order> {
        return this.sendRequest(RequestMethod.Post, 'postOrder', order);
    }

    getOrders(): Observable<OrderSummary[]> {
        return this.sendRequest(RequestMethod.Get, 'getOrders');
    }

    getOrderDetail(orderId: number): Observable<OrderDetail[]> {
        return this.sendRequest(RequestMethod.Get, `getOrderDetail/${orderId}`);
    }

    checkQuantities(skus: string[]): Observable<SkuQuantity[]> {
        return this.sendRequest(RequestMethod.Get, `checkQuantities/${skus}`);
    }

    private sendRequest(verb: RequestMethod, url: string,
        body?: Order) {
        return this.http.request(new Request({
            method: verb,
            url: this.baseurl + url,
            body: body
        })).map(response => response.json());
    }
}