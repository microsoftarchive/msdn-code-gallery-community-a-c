import { Routes,
    RouterModule }  from '@angular/router';

import {OverviewComponent} from './overview.component';
import {OfficeInteractionComponent} from './office-interaction.component';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'overview',
        pathMatch: 'full'        
    },
    {
        path: 'overview',
        component: OverviewComponent
    },
    {
        path: 'office',
        component: OfficeInteractionComponent
    }
];

export const demoRouting = RouterModule.forRoot(routes);