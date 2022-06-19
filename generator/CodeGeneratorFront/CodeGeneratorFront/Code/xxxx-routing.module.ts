import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { XxxxComponent } from './xxxx.component';
//import endTage

const routes: Routes = [{
    path: '',
    component: XxxxComponent,
    children: [
    //route endTage
    ],
}];
@NgModule({
    imports: [
        RouterModule.forChild(routes),
    ],
    exports: [
        RouterModule,
    ],
})
export class XxxxRoutingModule { }
