import { Routes, RouterModule } from '@angular/router';

import { ShopComponent } from './Shop/shop.component';
import { StylesByCategoryComponent } from './Shop/stylesByCategory.component';
import { StyleDetailComponent } from './Shop/styleDetail.component';
import { CartComponent } from './Shop/cart.component';
import { CheckoutComponent } from './Shop/checkout.component';
import { OrdersComponent } from './Shop/orders.component';

const routes: Routes = [
    { path: 'home', component: ShopComponent },
    { path: 'cart', component: CartComponent },
    { path: 'checkout', component: CheckoutComponent },
    { path: 'orders/:orderId/:totalValue', component: OrdersComponent},
    { path: 'orders', component: OrdersComponent },
    { path: 'category/:category/:selectedPage/:sort', 
        component: StylesByCategoryComponent },
    { path: 'styleDetail/:category/:styleNo', component: StyleDetailComponent },
    { path: '**', redirectTo: '/home' }
];

export const routing = RouterModule.forRoot(routes);