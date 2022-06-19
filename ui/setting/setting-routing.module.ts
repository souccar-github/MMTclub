import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { SettingComponent } from './setting.component';
import { StudentComponent } from './student/student.component';
import { CollegeComponent } from './college/college.component';
//import endTage

const routes: Routes = [{
    path: '',
    component: SettingComponent,
    children: [
       {
           path: 'student',
           component: StudentComponent,
           data: { permission : 'Page.Student' },
           canActivate: [AppRouteGuard]
       },

       {
           path: 'college',
           component: CollegeComponent,
           data: { permission : 'Page.College' },
           canActivate: [AppRouteGuard]
       },

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
export class SettingRoutingModule { }
