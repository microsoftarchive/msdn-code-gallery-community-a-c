import * as React from "react";
import t from './language';
import { MultilanguageState } from './MultilanguageState';
import { Label } from 'office-ui-fabric-react/lib/Label';
import { Icon } from 'office-ui-fabric-react/lib/Icon';
import {
  PivotItem,
  IPivotItemProps,
  Pivot
} from 'office-ui-fabric-react/lib/Pivot';

export interface MultilanguageProps { compiler: string; framework: string; }

// 'MultilanguageProps' describes the shape of props.
// State is never set so we use the 'undefined' type.
export class Multilanguage extends React.Component<MultilanguageProps, MultilanguageState> {

    public constructor(props: MultilanguageProps, state: MultilanguageState) {
        super(props);

        this.state = {
            status: '',
            currentLanguage: 0,
        };

        //this._getErrorMessage = this._getErrorMessage.bind(this);
    }

    public async componentWillMount() {
        console.log("componentWillMount!!");
        // get favorite language
        let favoriteLanguage = 'en'; //this.getUrlQueryString('SPLanguage');
        if (favoriteLanguage.search(/en/i) > -1) {
            this.setState({
                currentLanguage: 0
            });
        } else {
            this.setState({
                currentLanguage: 1
            });
        }
    }

    render() {
        return (
            <div>
                <Pivot onLinkClick={ this.onLinkClick.bind(this) }>
                    <PivotItem linkText='English' itemIcon='TextBox' itemKey='en'>
                    </PivotItem>
                    <PivotItem linkText='German' itemIcon='TextBox' itemKey='de'>
                    </PivotItem>
                    <PivotItem linkText='Italian' itemIcon='TextBox' itemKey='it'>
                    </PivotItem>
                    <PivotItem linkText='Spanish' itemIcon='TextBox' itemKey='es'>
                    </PivotItem>
                </Pivot> 
                <h1>{t[this.state.currentLanguage].welcome} {this.props.compiler} {this.props.framework} App!</h1>
                <h2>{t[this.state.currentLanguage].description}</h2>
            </div>
        );
    }

    public onLinkClick(item: PivotItem): void {
        console.log(item.props.linkText);
        let languageSelected = 0;
        switch (item.props.itemKey) {
            case "de":
                languageSelected = 1;
                break;
            case "it":
                languageSelected = 2;
                break;
            case "es":
                languageSelected = 3;
                break;
        }
        this.setState({
            currentLanguage: languageSelected
        })
    }
}