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
    XxxServiceProxy, UpdateXxxDto,
    //import proxy endTag
} from '@shared/service-proxies/service-proxies';
import { NbDialogRef } from '@nebular/theme';
//import endTag

@Component({
    templateUrl: 'edit-xxx-dialog.component.html',
    styleUrls: ['edit-xxx-dialog.component.scss']
})
export class EditXxxDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    xxx: UpdateXxxDto = new UpdateXxxDto();
    id: number;
    //declare endTag
    @Output() onSave = new EventEmitter<any>();

    constructor(
        injector: Injector,
        public _xxxService: XxxServiceProxy,
        //ctor endTag
        public dialogRef: NbDialogRef<EditXxxDialogComponent>
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._xxxService.getForEdit(this.id).subscribe((result: UpdateXxxDto) => {
            this.xxx = result;
        });

        //init endTag
    }

    save(): void {
        this.saving = true;

        this._xxxService
            .update(this.xxx)
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

    //func endTag
}
