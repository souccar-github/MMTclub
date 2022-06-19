import {
    Component,
    Injector,
    OnInit,
    Output,
    EventEmitter
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import {
    CollegeServiceProxy, UpdateCollegeDto,
    ,



} from '@shared/service-proxies/service-proxies';
import { NbDialogRef } from '@nebular/theme';
//import endTag

@Component({
    templateUrl: 'edit-college-dialog.component.html',
    styleUrls: ['edit-college-dialog.component.scss']
})
export class EditCollegeDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    college: UpdateCollegeDto = new UpdateCollegeDto();
    id: number;
    
    @Output() onSave = new EventEmitter<any>();

    constructor(
        injector: Injector,
        public _collegeService: CollegeServiceProxy,
        
        public dialogRef: NbDialogRef<EditCollegeDialogComponent>
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._collegeService.getForEdit(this.id).subscribe((result: UpdateCollegeDto) => {
            this.college = result;
        });

        
    }

    save(): void {
        this.saving = true;

        this._collegeService
            .update(this.college)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.dialogRef.close();
                this.onSave.emit();
            });
    }

    
}
