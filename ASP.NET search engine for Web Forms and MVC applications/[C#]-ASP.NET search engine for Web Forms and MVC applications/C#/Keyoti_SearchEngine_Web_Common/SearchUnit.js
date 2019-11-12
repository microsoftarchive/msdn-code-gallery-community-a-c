/*#<![CDATA[*/
//-For version 6.0.0
/*
 * jQuery 1.2.6 - New Wave Javascript
 *
 * Copyright (c) 2008 John Resig (jquery.com)
 * Dual licensed under the MIT (MIT-LICENSE.txt)
 * and GPL (GPL-LICENSE.txt) licenses.
 *
 * $Date: 2008-05-24 14:22:17 -0400 (Sat, 24 May 2008) $
 * $Rev: 5685 $
 */
(function(){var _KSQ=window.KSQ;var KSQ=window.KSQ=function(selector,context){return new KSQ.fn.init(selector,context)};var quickExpr=/^[^<]*(<(.|\s)+>)[^>]*$|^#(\w+)$/,isSimple=/^.[^:#\[\.]*$/,undefined;KSQ.fn=KSQ.prototype={init:function(selector,context){selector=selector||document;if(selector.nodeType){this[0]=selector;this.length=1;return this}if(typeof selector=="string"){var match=quickExpr.exec(selector);if(match&&(match[1]||!context)){if(match[1])selector=KSQ.clean([match[1]],context);else{var elem=document.getElementById(match[3]);if(elem){if(elem.id!=match[3])return KSQ().find(selector);return KSQ(elem)}selector=[]}}else return KSQ(context).find(selector)}else if(KSQ.isFunction(selector))return KSQ(document)[KSQ.fn.ready?"ready":"load"](selector);return this.setArray(KSQ.makeArray(selector))},KSQ:"1.2.6",size:function(){return this.length},length:0,get:function(num){return num==undefined?KSQ.makeArray(this):this[num]},pushStack:function(elems){var ret=KSQ(elems);ret.prevObject=this;
return ret},setArray:function(elems){this.length=0;Array.prototype.push.apply(this,elems);return this},each:function(callback,args){return KSQ.each(this,callback,args)},index:function(elem){var ret=-1;return KSQ.inArray(elem&&elem.KSQ?elem[0]:elem,this)},attr:function(name,value,type){var options=name;if(name.constructor==String)if(value===undefined)return this[0]&&KSQ[type||"attr"](this[0],name);else{options={};options[name]=value}return this.each(function(i){for(name in options)KSQ.attr(type?this.style:this,name,KSQ.prop(this,options[name],type,i,name))})},css:function(key,value){if((key=="width"||key=="height")&&parseFloat(value)<0)value=undefined;return this.attr(key,value,"curCSS")},text:function(text){if(typeof text!="object"&&text!=null)return this.empty().append((this[0]&&this[0].ownerDocument||document).createTextNode(text));var ret="";KSQ.each(text||this,function(){KSQ.each(this.childNodes,function(){if(this.nodeType!=8)ret+=this.nodeType!=1?this.nodeValue:KSQ.fn.text([this])})
});return ret},wrapAll:function(html){if(this[0])KSQ(html,this[0].ownerDocument).clone().insertBefore(this[0]).map(function(){var elem=this;while(elem.firstChild)elem=elem.firstChild;return elem}).append(this);return this},wrapInner:function(html){return this.each(function(){KSQ(this).contents().wrapAll(html)})},wrap:function(html){return this.each(function(){KSQ(this).wrapAll(html)})},append:function(){return this.domManip(arguments,true,false,function(elem){if(this.nodeType==1)this.appendChild(elem)})},prepend:function(){return this.domManip(arguments,true,true,function(elem){if(this.nodeType==1)this.insertBefore(elem,this.firstChild)})},before:function(){return this.domManip(arguments,false,false,function(elem){this.parentNode.insertBefore(elem,this)})},after:function(){return this.domManip(arguments,false,true,function(elem){this.parentNode.insertBefore(elem,this.nextSibling)})},end:function(){return this.prevObject||KSQ([])},find:function(selector){var elems=KSQ.map(this,function(elem){return KSQ.find(selector,elem)
});return this.pushStack(/[^+>] [^+>]/.test(selector)||selector.indexOf("..")>-1?KSQ.unique(elems):elems)},clone:function(events){var ret=this.map(function(){if(KSQ.browser.msie&&!KSQ.isXMLDoc(this)){var clone=this.cloneNode(true),container=document.createElement("div");container.appendChild(clone);return KSQ.clean([container.innerHTML])[0]}else return this.cloneNode(true)});var clone=ret.find("*").andSelf().each(function(){if(this[expando]!=undefined)this[expando]=null});if(events===true)this.find("*").andSelf().each(function(i){if(this.nodeType==3)return;var events=KSQ.data(this,"events");for(var type in events)for(var handler in events[type])KSQ.event.add(clone[i],type,events[type][handler],events[type][handler].data)});return ret},filter:function(selector){return this.pushStack(KSQ.isFunction(selector)&&KSQ.grep(this,function(elem,i){return selector.call(elem,i)})||KSQ.multiFilter(selector,this))},not:function(selector){if(selector.constructor==String)if(isSimple.test(selector))return this.pushStack(KSQ.multiFilter(selector,this,true));
else selector=KSQ.multiFilter(selector,this);var isArrayLike=selector.length&&selector[selector.length-1]!==undefined&&!selector.nodeType;return this.filter(function(){return isArrayLike?KSQ.inArray(this,selector)<0:this!=selector})},add:function(selector){return this.pushStack(KSQ.unique(KSQ.merge(this.get(),typeof selector=="string"?KSQ(selector):KSQ.makeArray(selector))))},is:function(selector){return!!selector&&KSQ.multiFilter(selector,this).length>0},hasClass:function(selector){return this.is("."+selector)},val:function(value){if(value==undefined){if(this.length){var elem=this[0];if(KSQ.nodeName(elem,"select")){var index=elem.selectedIndex,values=[],options=elem.options,one=elem.type=="select-one";if(index<0)return null;for(var i=one?index:0,max=one?index+1:options.length;i<max;i++){var option=options[i];if(option.selected){value=KSQ.browser.msie&&!option.attributes.value.specified?option.text:option.value;if(one)return value;values.push(value)}}return values}else return(this[0].value||"").replace(/\r/g,"")
}return undefined}if(value.constructor==Number)value+="";return this.each(function(){if(this.nodeType!=1)return;if(value.constructor==Array&&/radio|checkbox/.test(this.type))this.checked=KSQ.inArray(this.value,value)>=0||KSQ.inArray(this.name,value)>=0;else if(KSQ.nodeName(this,"select")){var values=KSQ.makeArray(value);KSQ("option",this).each(function(){this.selected=KSQ.inArray(this.value,values)>=0||KSQ.inArray(this.text,values)>=0});if(!values.length)this.selectedIndex=-1}else this.value=value})},html:function(value){return value==undefined?this[0]?this[0].innerHTML:null:this.empty().append(value)},replaceWith:function(value){return this.after(value).remove()},eq:function(i){return this.slice(i,i+1)},slice:function(){return this.pushStack(Array.prototype.slice.apply(this,arguments))},map:function(callback){return this.pushStack(KSQ.map(this,function(elem,i){return callback.call(elem,i,elem)}))},andSelf:function(){return this.add(this.prevObject)},data:function(key,value){var parts=key.split(".");
parts[1]=parts[1]?"."+parts[1]:"";if(value===undefined){var data=this.triggerHandler("getData"+parts[1]+"!",[parts[0]]);if(data===undefined&&this.length)data=KSQ.data(this[0],key);return data===undefined&&parts[1]?this.data(parts[0]):data}else return this.trigger("setData"+parts[1]+"!",[parts[0],value]).each(function(){KSQ.data(this,key,value)})},removeData:function(key){return this.each(function(){KSQ.removeData(this,key)})},domManip:function(args,table,reverse,callback){var clone=this.length>1,elems;return this.each(function(){if(!elems){elems=KSQ.clean(args,this.ownerDocument);if(reverse)elems.reverse()}var obj=this;if(table&&KSQ.nodeName(this,"table")&&KSQ.nodeName(elems[0],"tr"))obj=this.getElementsByTagName("tbody")[0]||this.appendChild(this.ownerDocument.createElement("tbody"));var scripts=KSQ([]);KSQ.each(elems,function(){var elem=clone?KSQ(this).clone(true)[0]:this;if(KSQ.nodeName(elem,"script"))scripts=scripts.add(elem);else{if(elem.nodeType==1)scripts=scripts.add(KSQ("script",elem).remove());
callback.call(obj,elem)}});scripts.each(evalScript)})}};KSQ.fn.init.prototype=KSQ.fn;function evalScript(i,elem){if(elem.src)KSQ.ajax({url:elem.src,async:false,dataType:"script"});else KSQ.globalEval(elem.text||elem.textContent||elem.innerHTML||"");if(elem.parentNode)elem.parentNode.removeChild(elem)}function now(){return+new Date}KSQ.extend=KSQ.fn.extend=function(){var target=arguments[0]||{},i=1,length=arguments.length,deep=false,options;if(target.constructor==Boolean){deep=target;target=arguments[1]||{};i=2}if(typeof target!="object"&&typeof target!="function")target={};if(length==i){target=this;--i}for(;i<length;i++)if((options=arguments[i])!=null)for(var name in options){var src=target[name],copy=options[name];if(target===copy)continue;if(deep&&copy&&typeof copy=="object"&&!copy.nodeType)target[name]=KSQ.extend(deep,src||(copy.length!=null?[]:{}),copy);else if(copy!==undefined)target[name]=copy}return target};var expando="KSQ"+now(),uuid=0,windowData={},exclude=/z-?index|font-?weight|opacity|zoom|line-?height/i,defaultView=document.defaultView||{};
KSQ.extend({noConflict:function(deep){window.$=_$;if(deep)window.KSQ=_KSQ;return KSQ},isFunction:function(fn){return!!fn&&typeof fn!="string"&&!fn.nodeName&&fn.constructor!=Array&&/^[\s[]?function/.test(fn+"")},isXMLDoc:function(elem){return elem.documentElement&&!elem.body||elem.tagName&&elem.ownerDocument&&!elem.ownerDocument.body},globalEval:function(data){data=KSQ.trim(data);if(data){var head=document.getElementsByTagName("head")[0]||document.documentElement,script=document.createElement("script");script.type="text/javascript";if(KSQ.browser.msie)script.text=data;else script.appendChild(document.createTextNode(data));head.insertBefore(script,head.firstChild);head.removeChild(script)}},nodeName:function(elem,name){return elem.nodeName&&elem.nodeName.toUpperCase()==name.toUpperCase()},cache:{},data:function(elem,name,data){elem=elem==window?windowData:elem;var id=elem[expando];if(!id)id=elem[expando]=++uuid;if(name&&!KSQ.cache[id])KSQ.cache[id]={};if(data!==undefined)KSQ.cache[id][name]=data;
return name?KSQ.cache[id][name]:id},removeData:function(elem,name){elem=elem==window?windowData:elem;var id=elem[expando];if(name){if(KSQ.cache[id]){delete KSQ.cache[id][name];name="";for(name in KSQ.cache[id])break;if(!name)KSQ.removeData(elem)}}else{try{delete elem[expando]}catch(e){if(elem.removeAttribute)elem.removeAttribute(expando)}delete KSQ.cache[id]}},each:function(object,callback,args){var name,i=0,length=object.length;if(args){if(length==undefined){for(name in object)if(callback.apply(object[name],args)===false)break}else for(;i<length;)if(callback.apply(object[i++],args)===false)break}else{if(length==undefined){for(name in object)if(callback.call(object[name],name,object[name])===false)break}else for(var value=object[0];i<length&&callback.call(value,i,value)!==false;value=object[++i]){}}return object},prop:function(elem,value,type,i,name){if(KSQ.isFunction(value))value=value.call(elem,i);return value&&value.constructor==Number&&type=="curCSS"&&!exclude.test(name)?value+"px":value
},className:{add:function(elem,classNames){KSQ.each((classNames||"").split(/\s+/),function(i,className){if(elem.nodeType==1&&!KSQ.className.has(elem.className,className))elem.className+=(elem.className?" ":"")+className})},remove:function(elem,classNames){if(elem.nodeType==1)elem.className=classNames!=undefined?KSQ.grep(elem.className.split(/\s+/),function(className){return!KSQ.className.has(classNames,className)}).join(" "):""},has:function(elem,className){return KSQ.inArray(className,(elem.className||elem).toString().split(/\s+/))>-1}},swap:function(elem,options,callback){var old={};for(var name in options){old[name]=elem.style[name];elem.style[name]=options[name]}callback.call(elem);for(var name in options)elem.style[name]=old[name]},css:function(elem,name,force){if(name=="width"||name=="height"){var val,props={position:"absolute",visibility:"hidden",display:"block"},which=name=="width"?["Left","Right"]:["Top","Bottom"];function getWH(){val=name=="width"?elem.offsetWidth:elem.offsetHeight;
var padding=0,border=0;KSQ.each(which,function(){padding+=parseFloat(KSQ.curCSS(elem,"padding"+this,true))||0;border+=parseFloat(KSQ.curCSS(elem,"border"+this+"Width",true))||0});val-=Math.round(padding+border)}if(KSQ(elem).is(":visible"))getWH();else KSQ.swap(elem,props,getWH);return Math.max(0,val)}return KSQ.curCSS(elem,name,force)},curCSS:function(elem,name,force){var ret,style=elem.style;function color(elem){if(!KSQ.browser.safari)return false;var ret=defaultView.getComputedStyle(elem,null);return!ret||ret.getPropertyValue("color")==""}if(name=="opacity"&&KSQ.browser.msie){ret=KSQ.attr(style,"opacity");return ret==""?"1":ret}if(KSQ.browser.opera&&name=="display"){var save=style.outline;style.outline="0 solid black";style.outline=save}if(name.match(/float/i))name=styleFloat;if(!force&&style&&style[name])ret=style[name];else if(defaultView.getComputedStyle){if(name.match(/float/i))name="float";name=name.replace(/([A-Z])/g,"-$1").toLowerCase();var computedStyle=defaultView.getComputedStyle(elem,null);
if(computedStyle&&!color(elem))ret=computedStyle.getPropertyValue(name);else{var swap=[],stack=[],a=elem,i=0;for(;a&&color(a);a=a.parentNode)stack.unshift(a);for(;i<stack.length;i++)if(color(stack[i])){swap[i]=stack[i].style.display;stack[i].style.display="block"}ret=name=="display"&&swap[stack.length-1]!=null?"none":computedStyle&&computedStyle.getPropertyValue(name)||"";for(i=0;i<swap.length;i++)if(swap[i]!=null)stack[i].style.display=swap[i]}if(name=="opacity"&&ret=="")ret="1"}else if(elem.currentStyle){var camelCase=name.replace(/\-(\w)/g,function(all,letter){return letter.toUpperCase()});ret=elem.currentStyle[name]||elem.currentStyle[camelCase];if(!/^\d+(px)?$/i.test(ret)&&/^\d/.test(ret)){var left=style.left,rsLeft=elem.runtimeStyle.left;elem.runtimeStyle.left=elem.currentStyle.left;style.left=ret||0;ret=style.pixelLeft+"px";style.left=left;elem.runtimeStyle.left=rsLeft}}return ret},clean:function(elems,context){var ret=[];context=context||document;if(typeof context.createElement=="undefined")context=context.ownerDocument||context[0]&&context[0].ownerDocument||document;
KSQ.each(elems,function(i,elem){if(!elem)return;if(elem.constructor==Number)elem+="";if(typeof elem=="string"){elem=elem.replace(/(<(\w+)[^>]*?)\/>/g,function(all,front,tag){return tag.match(/^(abbr|br|col|img|input|link|meta|param|hr|area|embed)$/i)?all:front+"></"+tag+">"});var tags=KSQ.trim(elem).toLowerCase(),div=context.createElement("div");var wrap=!tags.indexOf("<opt")&&[1,"<select multiple='multiple'>","</select>"]||!tags.indexOf("<leg")&&[1,"<fieldset>","</fieldset>"]||tags.match(/^<(thead|tbody|tfoot|colg|cap)/)&&[1,"<table>","</table>"]||!tags.indexOf("<tr")&&[2,"<table><tbody>","</tbody></table>"]||(!tags.indexOf("<td")||!tags.indexOf("<th"))&&[3,"<table><tbody><tr>","</tr></tbody></table>"]||!tags.indexOf("<col")&&[2,"<table><tbody></tbody><colgroup>","</colgroup></table>"]||KSQ.browser.msie&&[1,"div<div>","</div>"]||[0,"",""];div.innerHTML=wrap[1]+elem+wrap[2];while(wrap[0]--)div=div.lastChild;if(KSQ.browser.msie){var tbody=!tags.indexOf("<table")&&tags.indexOf("<tbody")<0?div.firstChild&&div.firstChild.childNodes:wrap[1]=="<table>"&&tags.indexOf("<tbody")<0?div.childNodes:[];
for(var j=tbody.length-1;j>=0;--j)if(KSQ.nodeName(tbody[j],"tbody")&&!tbody[j].childNodes.length)tbody[j].parentNode.removeChild(tbody[j]);if(/^\s/.test(elem))div.insertBefore(context.createTextNode(elem.match(/^\s*/)[0]),div.firstChild)}elem=KSQ.makeArray(div.childNodes)}if(elem.length===0&&!KSQ.nodeName(elem,"form")&&!KSQ.nodeName(elem,"select"))return;if(elem[0]==undefined||KSQ.nodeName(elem,"form")||elem.options)ret.push(elem);else ret=KSQ.merge(ret,elem)});return ret},attr:function(elem,name,value){if(!elem||elem.nodeType==3||elem.nodeType==8)return undefined;var notxml=!KSQ.isXMLDoc(elem),set=value!==undefined,msie=KSQ.browser.msie;name=notxml&&KSQ.props[name]||name;if(elem.tagName){var special=/href|src|style/.test(name);if(name=="selected"&&KSQ.browser.safari)elem.parentNode.selectedIndex;if(name in elem&&notxml&&!special){if(set){if(name=="type"&&KSQ.nodeName(elem,"input")&&elem.parentNode)throw"type property can't be changed";elem[name]=value}if(KSQ.nodeName(elem,"form")&&elem.getAttributeNode(name))return elem.getAttributeNode(name).nodeValue;
return elem[name]}if(msie&&notxml&&name=="style")return KSQ.attr(elem.style,"cssText",value);if(set)elem.setAttribute(name,""+value);var attr=msie&&notxml&&special?elem.getAttribute(name,2):elem.getAttribute(name);return attr===null?undefined:attr}if(msie&&name=="opacity"){if(set){elem.zoom=1;elem.filter=(elem.filter||"").replace(/alpha\([^)]*\)/,"")+(parseInt(value)+""=="NaN"?"":"alpha(opacity="+value*100+")")}return elem.filter&&elem.filter.indexOf("opacity=")>=0?parseFloat(elem.filter.match(/opacity=([^)]*)/)[1])/100+"":""}name=name.replace(/-([a-z])/gi,function(all,letter){return letter.toUpperCase()});if(set)elem[name]=value;return elem[name]},trim:function(text){return(text||"").replace(/^\s+|\s+$/g,"")},makeArray:function(array){var ret=[];if(array!=null){var i=array.length;if(i==null||array.split||array.setInterval||array.call)ret[0]=array;else while(i)ret[--i]=array[i]}return ret},inArray:function(elem,array){for(var i=0,length=array.length;i<length;i++)if(array[i]===elem)return i;
return-1},merge:function(first,second){var i=0,elem,pos=first.length;if(KSQ.browser.msie){while(elem=second[i++])if(elem.nodeType!=8)first[pos++]=elem}else while(elem=second[i++])first[pos++]=elem;return first},unique:function(array){var ret=[],done={};try{for(var i=0,length=array.length;i<length;i++){var id=KSQ.data(array[i]);if(!done[id]){done[id]=true;ret.push(array[i])}}}catch(e){ret=array}return ret},grep:function(elems,callback,inv){var ret=[];for(var i=0,length=elems.length;i<length;i++)if(!inv!=!callback(elems[i],i))ret.push(elems[i]);return ret},map:function(elems,callback){var ret=[];for(var i=0,length=elems.length;i<length;i++){var value=callback(elems[i],i);if(value!=null)ret[ret.length]=value}return ret.concat.apply([],ret)}});var userAgent=navigator.userAgent.toLowerCase();KSQ.browser={version:(userAgent.match(/.+(?:rv|it|ra|ie)[\/: ]([\d.]+)/)||[])[1],safari:/webkit/.test(userAgent),opera:/opera/.test(userAgent),msie:/msie/.test(userAgent)&&!/opera/.test(userAgent),mozilla:/mozilla/.test(userAgent)&&!/(compatible|webkit)/.test(userAgent)};
var styleFloat=KSQ.browser.msie?"styleFloat":"cssFloat";KSQ.extend({boxModel:!KSQ.browser.msie||document.compatMode=="CSS1Compat",props:{"for":"htmlFor","class":"className","float":styleFloat,cssFloat:styleFloat,styleFloat:styleFloat,readonly:"readOnly",maxlength:"maxLength",cellspacing:"cellSpacing"}});KSQ.each({parent:function(elem){return elem.parentNode},parents:function(elem){return KSQ.dir(elem,"parentNode")},next:function(elem){return KSQ.nth(elem,2,"nextSibling")},prev:function(elem){return KSQ.nth(elem,2,"previousSibling")},nextAll:function(elem){return KSQ.dir(elem,"nextSibling")},prevAll:function(elem){return KSQ.dir(elem,"previousSibling")},siblings:function(elem){return KSQ.sibling(elem.parentNode.firstChild,elem)},children:function(elem){return KSQ.sibling(elem.firstChild)},contents:function(elem){return KSQ.nodeName(elem,"iframe")?elem.contentDocument||elem.contentWindow.document:KSQ.makeArray(elem.childNodes)}},function(name,fn){KSQ.fn[name]=function(selector){var ret=KSQ.map(this,fn);
if(selector&&typeof selector=="string")ret=KSQ.multiFilter(selector,ret);return this.pushStack(KSQ.unique(ret))}});KSQ.each({appendTo:"append",prependTo:"prepend",insertBefore:"before",insertAfter:"after",replaceAll:"replaceWith"},function(name,original){KSQ.fn[name]=function(){var args=arguments;return this.each(function(){for(var i=0,length=args.length;i<length;i++)KSQ(args[i])[original](this)})}});KSQ.each({removeAttr:function(name){KSQ.attr(this,name,"");if(this.nodeType==1)this.removeAttribute(name)},addClass:function(classNames){KSQ.className.add(this,classNames)},removeClass:function(classNames){KSQ.className.remove(this,classNames)},toggleClass:function(classNames){KSQ.className[KSQ.className.has(this,classNames)?"remove":"add"](this,classNames)},remove:function(selector){if(!selector||KSQ.filter(selector,[this]).r.length){KSQ("*",this).add(this).each(function(){KSQ.event.remove(this);KSQ.removeData(this)});if(this.parentNode)this.parentNode.removeChild(this)}},empty:function(){KSQ(">*",this).remove();
while(this.firstChild)this.removeChild(this.firstChild)}},function(name,fn){KSQ.fn[name]=function(){return this.each(fn,arguments)}});KSQ.each(["Height","Width"],function(i,name){var type=name.toLowerCase();KSQ.fn[type]=function(size){return this[0]==window?KSQ.browser.opera&&document.body["client"+name]||KSQ.browser.safari&&window["inner"+name]||document.compatMode=="CSS1Compat"&&document.documentElement["client"+name]||document.body["client"+name]:this[0]==document?Math.max(Math.max(document.body["scroll"+name],document.documentElement["scroll"+name]),Math.max(document.body["offset"+name],document.documentElement["offset"+name])):size==undefined?this.length?KSQ.css(this[0],type):null:this.css(type,size.constructor==String?size:size+"px")}});function num(elem,prop){return elem[0]&&parseInt(KSQ.curCSS(elem[0],prop,true),10)||0}var chars=KSQ.browser.safari&&parseInt(KSQ.browser.version)<417?"(?:[\\w*_-]|\\\\.)":"(?:[\\wĨ-￿*_-]|\\\\.)",quickChild=new RegExp("^>\\s*("+chars+"+)"),quickID=new RegExp("^("+chars+"+)(#)("+chars+"+)"),quickClass=new RegExp("^([#.]?)("+chars+"*)");
KSQ.extend({expr:{"":function(a,i,m){return m[2]=="*"||KSQ.nodeName(a,m[2])},"#":function(a,i,m){return a.getAttribute("id")==m[2]},":":{lt:function(a,i,m){return i<m[3]-0},gt:function(a,i,m){return i>m[3]-0},nth:function(a,i,m){return m[3]-0==i},eq:function(a,i,m){return m[3]-0==i},first:function(a,i){return i==0},last:function(a,i,m,r){return i==r.length-1},even:function(a,i){return i%2==0},odd:function(a,i){return i%2},"first-child":function(a){return a.parentNode.getElementsByTagName("*")[0]==a},"last-child":function(a){return KSQ.nth(a.parentNode.lastChild,1,"previousSibling")==a},"only-child":function(a){return!KSQ.nth(a.parentNode.lastChild,2,"previousSibling")},parent:function(a){return a.firstChild},empty:function(a){return!a.firstChild},contains:function(a,i,m){return(a.textContent||a.innerText||KSQ(a).text()||"").indexOf(m[3])>=0},visible:function(a){return"hidden"!=a.type&&KSQ.css(a,"display")!="none"&&KSQ.css(a,"visibility")!="hidden"},hidden:function(a){return"hidden"==a.type||KSQ.css(a,"display")=="none"||KSQ.css(a,"visibility")=="hidden"
},enabled:function(a){return!a.disabled},disabled:function(a){return a.disabled},checked:function(a){return a.checked},selected:function(a){return a.selected||KSQ.attr(a,"selected")},text:function(a){return"text"==a.type},radio:function(a){return"radio"==a.type},checkbox:function(a){return"checkbox"==a.type},file:function(a){return"file"==a.type},password:function(a){return"password"==a.type},submit:function(a){return"submit"==a.type},image:function(a){return"image"==a.type},reset:function(a){return"reset"==a.type},button:function(a){return"button"==a.type||KSQ.nodeName(a,"button")},input:function(a){return/input|select|textarea|button/i.test(a.nodeName)},has:function(a,i,m){return KSQ.find(m[3],a).length},header:function(a){return/h\d/i.test(a.nodeName)},animated:function(a){return KSQ.grep(KSQ.timers,function(fn){return a==fn.elem}).length}}},parse:[/^(\[) *@?([\w-]+) *([!*$^~=]*) *('?"?)(.*?)\4 *\]/,/^(:)([\w-]+)\("?'?(.*?(\(.*?\))?[^(]*?)"?'?\)/,new RegExp("^([:.#]*)("+chars+"+)")],multiFilter:function(expr,elems,not){var old,cur=[];
while(expr&&expr!=old){old=expr;var f=KSQ.filter(expr,elems,not);expr=f.t.replace(/^\s*,\s*/,"");cur=not?elems=f.r:KSQ.merge(cur,f.r)}return cur},find:function(t,context){if(typeof t!="string")return[t];if(context&&context.nodeType!=1&&context.nodeType!=9)return[];context=context||document;var ret=[context],done=[],last,nodeName;while(t&&last!=t){var r=[];last=t;t=KSQ.trim(t);var foundToken=false,re=quickChild,m=re.exec(t);if(m){nodeName=m[1].toUpperCase();for(var i=0;ret[i];i++)for(var c=ret[i].firstChild;c;c=c.nextSibling)if(c.nodeType==1&&(nodeName=="*"||c.nodeName.toUpperCase()==nodeName))r.push(c);ret=r;t=t.replace(re,"");if(t.indexOf(" ")==0)continue;foundToken=true}else{re=/^([>+~])\s*(\w*)/i;if((m=re.exec(t))!=null){r=[];var merge={};nodeName=m[2].toUpperCase();m=m[1];for(var j=0,rl=ret.length;j<rl;j++){var n=m=="~"||m=="+"?ret[j].nextSibling:ret[j].firstChild;for(;n;n=n.nextSibling)if(n.nodeType==1){var id=KSQ.data(n);if(m=="~"&&merge[id])break;if(!nodeName||n.nodeName.toUpperCase()==nodeName){if(m=="~")merge[id]=true;
r.push(n)}if(m=="+")break}}ret=r;t=KSQ.trim(t.replace(re,""));foundToken=true}}if(t&&!foundToken){if(!t.indexOf(",")){if(context==ret[0])ret.shift();done=KSQ.merge(done,ret);r=ret=[context];t=" "+t.substr(1,t.length)}else{var re2=quickID;var m=re2.exec(t);if(m){m=[0,m[2],m[3],m[1]]}else{re2=quickClass;m=re2.exec(t)}m[2]=m[2].replace(/\\/g,"");var elem=ret[ret.length-1];if(m[1]=="#"&&elem&&elem.getElementById&&!KSQ.isXMLDoc(elem)){var oid=elem.getElementById(m[2]);if((KSQ.browser.msie||KSQ.browser.opera)&&oid&&typeof oid.id=="string"&&oid.id!=m[2])oid=KSQ('[@id="'+m[2]+'"]',elem)[0];ret=r=oid&&(!m[3]||KSQ.nodeName(oid,m[3]))?[oid]:[]}else{for(var i=0;ret[i];i++){var tag=m[1]=="#"&&m[3]?m[3]:m[1]!=""||m[0]==""?"*":m[2];if(tag=="*"&&ret[i].nodeName.toLowerCase()=="object")tag="param";r=KSQ.merge(r,ret[i].getElementsByTagName(tag))}if(m[1]==".")r=KSQ.classFilter(r,m[2]);if(m[1]=="#"){var tmp=[];for(var i=0;r[i];i++)if(r[i].getAttribute("id")==m[2]){tmp=[r[i]];break}r=tmp}ret=r}t=t.replace(re2,"")
}}if(t){var val=KSQ.filter(t,r);ret=r=val.r;t=KSQ.trim(val.t)}}if(t)ret=[];if(ret&&context==ret[0])ret.shift();done=KSQ.merge(done,ret);return done},classFilter:function(r,m,not){m=" "+m+" ";var tmp=[];for(var i=0;r[i];i++){var pass=(" "+r[i].className+" ").indexOf(m)>=0;if(!not&&pass||not&&!pass)tmp.push(r[i])}return tmp},filter:function(t,r,not){var last;while(t&&t!=last){last=t;var p=KSQ.parse,m;for(var i=0;p[i];i++){m=p[i].exec(t);if(m){t=t.substring(m[0].length);m[2]=m[2].replace(/\\/g,"");break}}if(!m)break;if(m[1]==":"&&m[2]=="not")r=isSimple.test(m[3])?KSQ.filter(m[3],r,true).r:KSQ(r).not(m[3]);else if(m[1]==".")r=KSQ.classFilter(r,m[2],not);else if(m[1]=="["){var tmp=[],type=m[3];for(var i=0,rl=r.length;i<rl;i++){var a=r[i],z=a[KSQ.props[m[2]]||m[2]];if(z==null||/href|src|selected/.test(m[2]))z=KSQ.attr(a,m[2])||"";if((type==""&&!!z||type=="="&&z==m[5]||type=="!="&&z!=m[5]||type=="^="&&z&&!z.indexOf(m[5])||type=="$="&&z.substr(z.length-m[5].length)==m[5]||(type=="*="||type=="~=")&&z.indexOf(m[5])>=0)^not)tmp.push(a)
}r=tmp}else if(m[1]==":"&&m[2]=="nth-child"){var merge={},tmp=[],test=/(-?)(\d*)n((?:\+|-)?\d*)/.exec(m[3]=="even"&&"2n"||m[3]=="odd"&&"2n+1"||!/\D/.test(m[3])&&"0n+"+m[3]||m[3]),first=test[1]+(test[2]||1)-0,last=test[3]-0;for(var i=0,rl=r.length;i<rl;i++){var node=r[i],parentNode=node.parentNode,id=KSQ.data(parentNode);if(!merge[id]){var c=1;for(var n=parentNode.firstChild;n;n=n.nextSibling)if(n.nodeType==1)n.nodeIndex=c++;merge[id]=true}var add=false;if(first==0){if(node.nodeIndex==last)add=true}else if((node.nodeIndex-last)%first==0&&(node.nodeIndex-last)/first>=0)add=true;if(add^not)tmp.push(node)}r=tmp}else{var fn=KSQ.expr[m[1]];if(typeof fn=="object")fn=fn[m[2]];if(typeof fn=="string")fn=eval("false||function(a,i){return "+fn+";}");r=KSQ.grep(r,function(elem,i){return fn(elem,i,m,r)},not)}}return{r:r,t:t}},dir:function(elem,dir){var matched=[],cur=elem[dir];while(cur&&cur!=document){if(cur.nodeType==1)matched.push(cur);cur=cur[dir]}return matched},nth:function(cur,result,dir,elem){result=result||1;
var num=0;for(;cur;cur=cur[dir])if(cur.nodeType==1&&++num==result)break;return cur},sibling:function(n,elem){var r=[];for(;n;n=n.nextSibling){if(n.nodeType==1&&n!=elem)r.push(n)}return r}});KSQ.event={add:function(elem,types,handler,data){if(elem.nodeType==3||elem.nodeType==8)return;if(KSQ.browser.msie&&elem.setInterval)elem=window;if(!handler.guid)handler.guid=this.guid++;if(data!=undefined){var fn=handler;handler=this.proxy(fn,function(){return fn.apply(this,arguments)});handler.data=data}var events=KSQ.data(elem,"events")||KSQ.data(elem,"events",{}),handle=KSQ.data(elem,"handle")||KSQ.data(elem,"handle",function(){if(typeof KSQ!="undefined"&&!KSQ.event.triggered)return KSQ.event.handle.apply(arguments.callee.elem,arguments)});handle.elem=elem;KSQ.each(types.split(/\s+/),function(index,type){var parts=type.split(".");type=parts[0];handler.type=parts[1];var handlers=events[type];if(!handlers){handlers=events[type]={};if(!KSQ.event.special[type]||KSQ.event.special[type].setup.call(elem)===false){if(elem.addEventListener)elem.addEventListener(type,handle,false);
else if(elem.attachEvent)elem.attachEvent("on"+type,handle)}}handlers[handler.guid]=handler;KSQ.event.global[type]=true});elem=null},guid:1,global:{},remove:function(elem,types,handler){if(elem.nodeType==3||elem.nodeType==8)return;var events=KSQ.data(elem,"events"),ret,index;if(events){if(types==undefined||typeof types=="string"&&types.charAt(0)==".")for(var type in events)this.remove(elem,type+(types||""));else{if(types.type){handler=types.handler;types=types.type}KSQ.each(types.split(/\s+/),function(index,type){var parts=type.split(".");type=parts[0];if(events[type]){if(handler)delete events[type][handler.guid];else for(handler in events[type])if(!parts[1]||events[type][handler].type==parts[1])delete events[type][handler];for(ret in events[type])break;if(!ret){if(!KSQ.event.special[type]||KSQ.event.special[type].teardown.call(elem)===false){if(elem.removeEventListener)elem.removeEventListener(type,KSQ.data(elem,"handle"),false);else if(elem.detachEvent)elem.detachEvent("on"+type,KSQ.data(elem,"handle"))
}ret=null;delete events[type]}}})}for(ret in events)break;if(!ret){var handle=KSQ.data(elem,"handle");if(handle)handle.elem=null;KSQ.removeData(elem,"events");KSQ.removeData(elem,"handle")}}},trigger:function(type,data,elem,donative,extra){data=KSQ.makeArray(data);if(type.indexOf("!")>=0){type=type.slice(0,-1);var exclusive=true}if(!elem){if(this.global[type])KSQ("*").add([window,document]).trigger(type,data)}else{if(elem.nodeType==3||elem.nodeType==8)return undefined;var val,ret,fn=KSQ.isFunction(elem[type]||null),event=!data[0]||!data[0].preventDefault;if(event){data.unshift({type:type,target:elem,preventDefault:function(){},stopPropagation:function(){},timeStamp:now()});data[0][expando]=true}data[0].type=type;if(exclusive)data[0].exclusive=true;var handle=KSQ.data(elem,"handle");if(handle)val=handle.apply(elem,data);if((!fn||KSQ.nodeName(elem,"a")&&type=="click")&&elem["on"+type]&&elem["on"+type].apply(elem,data)===false)val=false;if(event)data.shift();if(extra&&KSQ.isFunction(extra)){ret=extra.apply(elem,val==null?data:data.concat(val));
if(ret!==undefined)val=ret}if(fn&&donative!==false&&val!==false&&!(KSQ.nodeName(elem,"a")&&type=="click")){this.triggered=true;try{elem[type]()}catch(e){}}this.triggered=false}return val},handle:function(event){var val,ret,namespace,all,handlers;event=arguments[0]=KSQ.event.fix(event||window.event);namespace=event.type.split(".");event.type=namespace[0];namespace=namespace[1];all=!namespace&&!event.exclusive;handlers=(KSQ.data(this,"events")||{})[event.type];for(var j in handlers){var handler=handlers[j];if(all||handler.type==namespace){event.handler=handler;event.data=handler.data;ret=handler.apply(this,arguments);if(val!==false)val=ret;if(ret===false){event.preventDefault();event.stopPropagation()}}}return val},fix:function(event){if(event[expando]==true)return event;var originalEvent=event;event={originalEvent:originalEvent};var props="altKey attrChange attrName bubbles button cancelable charCode clientX clientY ctrlKey currentTarget data detail eventPhase fromElement handler keyCode metaKey newValue originalTarget pageX pageY prevValue relatedNode relatedTarget screenX screenY shiftKey srcElement target timeStamp toElement type view wheelDelta which".split(" ");
for(var i=props.length;i;i--)event[props[i]]=originalEvent[props[i]];event[expando]=true;event.preventDefault=function(){if(originalEvent.preventDefault)originalEvent.preventDefault();originalEvent.returnValue=false};event.stopPropagation=function(){if(originalEvent.stopPropagation)originalEvent.stopPropagation();originalEvent.cancelBubble=true};event.timeStamp=event.timeStamp||now();if(!event.target)event.target=event.srcElement||document;if(event.target.nodeType==3)event.target=event.target.parentNode;if(!event.relatedTarget&&event.fromElement)event.relatedTarget=event.fromElement==event.target?event.toElement:event.fromElement;if(event.pageX==null&&event.clientX!=null){var doc=document.documentElement,body=document.body;event.pageX=event.clientX+(doc&&doc.scrollLeft||body&&body.scrollLeft||0)-(doc.clientLeft||0);event.pageY=event.clientY+(doc&&doc.scrollTop||body&&body.scrollTop||0)-(doc.clientTop||0)}if(!event.which&&(event.charCode||event.charCode===0?event.charCode:event.keyCode))event.which=event.charCode||event.keyCode;
if(!event.metaKey&&event.ctrlKey)event.metaKey=event.ctrlKey;if(!event.which&&event.button)event.which=event.button&1?1:event.button&2?3:event.button&4?2:0;return event},proxy:function(fn,proxy){proxy.guid=fn.guid=fn.guid||proxy.guid||this.guid++;return proxy},special:{ready:{setup:function(){bindReady();return},teardown:function(){return}},mouseenter:{setup:function(){if(KSQ.browser.msie)return false;KSQ(this).bind("mouseover",KSQ.event.special.mouseenter.handler);return true},teardown:function(){if(KSQ.browser.msie)return false;KSQ(this).unbind("mouseover",KSQ.event.special.mouseenter.handler);return true},handler:function(event){if(withinElement(event,this))return true;event.type="mouseenter";return KSQ.event.handle.apply(this,arguments)}},mouseleave:{setup:function(){if(KSQ.browser.msie)return false;KSQ(this).bind("mouseout",KSQ.event.special.mouseleave.handler);return true},teardown:function(){if(KSQ.browser.msie)return false;KSQ(this).unbind("mouseout",KSQ.event.special.mouseleave.handler);
return true},handler:function(event){if(withinElement(event,this))return true;event.type="mouseleave";return KSQ.event.handle.apply(this,arguments)}}}};KSQ.fn.extend({bind:function(type,data,fn){return type=="unload"?this.one(type,data,fn):this.each(function(){KSQ.event.add(this,type,fn||data,fn&&data)})},one:function(type,data,fn){var one=KSQ.event.proxy(fn||data,function(event){KSQ(this).unbind(event,one);return(fn||data).apply(this,arguments)});return this.each(function(){KSQ.event.add(this,type,one,fn&&data)})},unbind:function(type,fn){return this.each(function(){KSQ.event.remove(this,type,fn)})},trigger:function(type,data,fn){return this.each(function(){KSQ.event.trigger(type,data,this,true,fn)})},triggerHandler:function(type,data,fn){return this[0]&&KSQ.event.trigger(type,data,this[0],false,fn)},toggle:function(fn){var args=arguments,i=1;while(i<args.length)KSQ.event.proxy(fn,args[i++]);return this.click(KSQ.event.proxy(fn,function(event){this.lastToggle=(this.lastToggle||0)%i;event.preventDefault();
return args[this.lastToggle++].apply(this,arguments)||false}))},hover:function(fnOver,fnOut){return this.bind("mouseenter",fnOver).bind("mouseleave",fnOut)},ready:function(fn){bindReady();if(KSQ.isReady)fn.call(document,KSQ);else KSQ.readyList.push(function(){return fn.call(this,KSQ)});return this}});KSQ.extend({isReady:false,readyList:[],ready:function(){if(!KSQ.isReady){KSQ.isReady=true;if(KSQ.readyList){KSQ.each(KSQ.readyList,function(){this.call(document)});KSQ.readyList=null}KSQ(document).triggerHandler("ready")}}});var readyBound=false;function bindReady(){if(readyBound)return;readyBound=true;if(document.addEventListener&&!KSQ.browser.opera)document.addEventListener("DOMContentLoaded",KSQ.ready,false);if(KSQ.browser.msie&&window==top)(function(){if(KSQ.isReady)return;try{document.documentElement.doScroll("left")}catch(error){setTimeout(arguments.callee,0);return}KSQ.ready()})();if(KSQ.browser.opera)document.addEventListener("DOMContentLoaded",function(){if(KSQ.isReady)return;for(var i=0;i<document.styleSheets.length;i++)if(document.styleSheets[i].disabled){setTimeout(arguments.callee,0);
return}KSQ.ready()},false);if(KSQ.browser.safari){var numStyles;(function(){if(KSQ.isReady)return;if(document.readyState!="loaded"&&document.readyState!="complete"){setTimeout(arguments.callee,0);return}if(numStyles===undefined)numStyles=KSQ("style, link[rel=stylesheet]").length;if(document.styleSheets.length!=numStyles){setTimeout(arguments.callee,0);return}KSQ.ready()})()}KSQ.event.add(window,"load",KSQ.ready)}KSQ.each(("blur,focus,load,resize,scroll,unload,click,dblclick,"+"mousedown,mouseup,mousemove,mouseover,mouseout,change,select,"+"submit,keydown,keypress,keyup,error").split(","),function(i,name){KSQ.fn[name]=function(fn){return fn?this.bind(name,fn):this.trigger(name)}});var withinElement=function(event,elem){var parent=event.relatedTarget;while(parent&&parent!=elem)try{parent=parent.parentNode}catch(error){parent=elem}return parent==elem};KSQ(window).bind("unload",function(){KSQ("*").add(document).unbind()});KSQ.fn.extend({_load:KSQ.fn.load,load:function(url,params,callback){if(typeof url!="string")return this._load(url);
var off=url.indexOf(" ");if(off>=0){var selector=url.slice(off,url.length);url=url.slice(0,off)}callback=callback||function(){};var type="GET";if(params)if(KSQ.isFunction(params)){callback=params;params=null}else{params=KSQ.param(params);type="POST"}var self=this;KSQ.ajax({url:url,type:type,dataType:"html",data:params,complete:function(res,status){if(status=="success"||status=="notmodified")self.html(selector?KSQ("<div/>").append(res.responseText.replace(/<script(.|\s)*?\/script>/g,"")).find(selector):res.responseText);self.each(callback,[res.responseText,status,res])}});return this},serialize:function(){return KSQ.param(this.serializeArray())},serializeArray:function(){return this.map(function(){return KSQ.nodeName(this,"form")?KSQ.makeArray(this.elements):this}).filter(function(){return this.name&&!this.disabled&&(this.checked||/select|textarea/i.test(this.nodeName)||/text|hidden|password/i.test(this.type))}).map(function(i,elem){var val=KSQ(this).val();return val==null?null:val.constructor==Array?KSQ.map(val,function(val,i){return{name:elem.name,value:val}
}):{name:elem.name,value:val}}).get()}});KSQ.each("ajaxStart,ajaxStop,ajaxComplete,ajaxError,ajaxSuccess,ajaxSend".split(","),function(i,o){KSQ.fn[o]=function(f){return this.bind(o,f)}});var jsc=now();KSQ.extend({get:function(url,data,callback,type){if(KSQ.isFunction(data)){callback=data;data=null}return KSQ.ajax({type:"GET",url:url,data:data,success:callback,dataType:type})},getScript:function(url,callback){return KSQ.get(url,null,callback,"script")},getJSON:function(url,data,callback){return KSQ.get(url,data,callback,"json")},post:function(url,data,callback,type){if(KSQ.isFunction(data)){callback=data;data={}}return KSQ.ajax({type:"POST",url:url,data:data,success:callback,dataType:type})},ajaxSetup:function(settings){KSQ.extend(KSQ.ajaxSettings,settings)},ajaxSettings:{url:location.href,global:true,type:"GET",timeout:0,contentType:"application/x-www-form-urlencoded",processData:true,async:true,data:null,username:null,password:null,accepts:{xml:"application/xml, text/xml",html:"text/html",script:"text/javascript, application/javascript",json:"application/json, text/javascript",text:"text/plain",_default:"*/*"}},lastModified:{},ajax:function(s){s=KSQ.extend(true,s,KSQ.extend(true,{},KSQ.ajaxSettings,s));
var jsonp,jsre=/=\?(&|$)/g,status,data,type=s.type.toUpperCase();if(s.data&&s.processData&&typeof s.data!="string")s.data=KSQ.param(s.data);if(s.dataType=="jsonp"){if(type=="GET"){if(!s.url.match(jsre))s.url+=(s.url.match(/\?/)?"&":"?")+(s.jsonp||"callback")+"=?"}else if(!s.data||!s.data.match(jsre))s.data=(s.data?s.data+"&":"")+(s.jsonp||"callback")+"=?";s.dataType="json"}if(s.dataType=="json"&&(s.data&&s.data.match(jsre)||s.url.match(jsre))){jsonp="jsonp"+jsc++;if(s.data)s.data=(s.data+"").replace(jsre,"="+jsonp+"$1");s.url=s.url.replace(jsre,"="+jsonp+"$1");s.dataType="script";window[jsonp]=function(tmp){data=tmp;success();complete();window[jsonp]=undefined;try{delete window[jsonp]}catch(e){}if(head)head.removeChild(script)}}if(s.dataType=="script"&&s.cache==null)s.cache=false;if(s.cache===false&&type=="GET"){var ts=now();var ret=s.url.replace(/(\?|&)_=.*?(&|$)/,"$1_="+ts+"$2");s.url=ret+(ret==s.url?(s.url.match(/\?/)?"&":"?")+"_="+ts:"")}if(s.data&&type=="GET"){s.url+=(s.url.match(/\?/)?"&":"?")+s.data;
s.data=null}if(s.global&&!KSQ.active++)KSQ.event.trigger("ajaxStart");var remote=/^(?:\w+:)?\/\/([^\/?#]+)/;if(s.dataType=="script"&&type=="GET"&&remote.test(s.url)&&remote.exec(s.url)[1]!=location.host){var head=document.getElementsByTagName("head")[0];var script=document.createElement("script");script.src=s.url;if(s.scriptCharset)script.charset=s.scriptCharset;if(!jsonp){var done=false;script.onload=script.onreadystatechange=function(){if(!done&&(!this.readyState||this.readyState=="loaded"||this.readyState=="complete")){done=true;success();complete();head.removeChild(script)}}}head.appendChild(script);return undefined}var requestDone=false;var xhr=window.ActiveXObject?new ActiveXObject("Microsoft.XMLHTTP"):new XMLHttpRequest;if(s.username)xhr.open(type,s.url,s.async,s.username,s.password);else xhr.open(type,s.url,s.async);try{if(s.data)xhr.setRequestHeader("Content-Type",s.contentType);if(s.ifModified)xhr.setRequestHeader("If-Modified-Since",KSQ.lastModified[s.url]||"Thu, 01 Jan 1970 00:00:00 GMT");
xhr.setRequestHeader("X-Requested-With","XMLHttpRequest");xhr.setRequestHeader("Accept",s.dataType&&s.accepts[s.dataType]?s.accepts[s.dataType]+", */*":s.accepts._default)}catch(e){}if(s.beforeSend&&s.beforeSend(xhr,s)===false){s.global&&KSQ.active--;xhr.abort();return false}if(s.global)KSQ.event.trigger("ajaxSend",[xhr,s]);var onreadystatechange=function(isTimeout){if(!requestDone&&xhr&&(xhr.readyState==4||isTimeout=="timeout")){requestDone=true;if(ival){clearInterval(ival);ival=null}status=isTimeout=="timeout"&&"timeout"||!KSQ.httpSuccess(xhr)&&"error"||s.ifModified&&KSQ.httpNotModified(xhr,s.url)&&"notmodified"||"success";if(status=="success"){try{data=KSQ.httpData(xhr,s.dataType,s.dataFilter)}catch(e){status="parsererror"}}if(status=="success"){var modRes;try{modRes=xhr.getResponseHeader("Last-Modified")}catch(e){}if(s.ifModified&&modRes)KSQ.lastModified[s.url]=modRes;if(!jsonp)success()}else KSQ.handleError(s,xhr,status);complete();if(s.async)xhr=null}};if(s.async){var ival=setInterval(onreadystatechange,13);
if(s.timeout>0)setTimeout(function(){if(xhr){xhr.abort();if(!requestDone)onreadystatechange("timeout")}},s.timeout)}try{xhr.send(s.data)}catch(e){KSQ.handleError(s,xhr,null,e)}if(!s.async)onreadystatechange();function success(){if(s.success)s.success(data,status);if(s.global)KSQ.event.trigger("ajaxSuccess",[xhr,s])}function complete(){if(s.complete)s.complete(xhr,status);if(s.global)KSQ.event.trigger("ajaxComplete",[xhr,s]);if(s.global&&!--KSQ.active)KSQ.event.trigger("ajaxStop")}return xhr},handleError:function(s,xhr,status,e){if(s.error)s.error(xhr,status,e);if(s.global)KSQ.event.trigger("ajaxError",[xhr,s,e])},active:0,httpSuccess:function(xhr){try{return!xhr.status&&location.protocol=="file:"||xhr.status>=200&&xhr.status<300||xhr.status==304||xhr.status==1223||KSQ.browser.safari&&xhr.status==undefined}catch(e){}return false},httpNotModified:function(xhr,url){try{var xhrRes=xhr.getResponseHeader("Last-Modified");return xhr.status==304||xhrRes==KSQ.lastModified[url]||KSQ.browser.safari&&xhr.status==undefined
}catch(e){}return false},httpData:function(xhr,type,filter){var ct=xhr.getResponseHeader("content-type"),xml=type=="xml"||!type&&ct&&ct.indexOf("xml")>=0,data=xml?xhr.responseXML:xhr.responseText;if(xml&&data.documentElement.tagName=="parsererror")throw"parsererror";if(filter)data=filter(data,type);if(type=="script")KSQ.globalEval(data);if(type=="json")data=/*eval("(" + data + ")");*/JSON.parse(data);return data},param:function(a){var s=[];if(a.constructor==Array||a.KSQ)KSQ.each(a,function(){s.push(encodeURIComponent(this.name)+"="+encodeURIComponent(this.value))});else for(var j in a)if(a[j]&&a[j].constructor==Array)KSQ.each(a[j],function(){s.push(encodeURIComponent(j)+"="+encodeURIComponent(this))});else s.push(encodeURIComponent(j)+"="+encodeURIComponent(KSQ.isFunction(a[j])?a[j]():a[j]));return s.join("&").replace(/%20/g,"+")}});KSQ.fn.extend({show:function(speed,callback){return speed?this.animate({height:"show",width:"show",opacity:"show"},speed,callback):this.filter(":hidden").each(function(){this.style.display=this.oldblock||"";
if(KSQ.css(this,"display")=="none"){var elem=KSQ("<"+this.tagName+" />").appendTo("body");this.style.display=elem.css("display");if(this.style.display=="none")this.style.display="block";elem.remove()}}).end()},hide:function(speed,callback){return speed?this.animate({height:"hide",width:"hide",opacity:"hide"},speed,callback):this.filter(":visible").each(function(){this.oldblock=this.oldblock||KSQ.css(this,"display");this.style.display="none"}).end()},_toggle:KSQ.fn.toggle,toggle:function(fn,fn2){return KSQ.isFunction(fn)&&KSQ.isFunction(fn2)?this._toggle.apply(this,arguments):fn?this.animate({height:"toggle",width:"toggle",opacity:"toggle"},fn,fn2):this.each(function(){KSQ(this)[KSQ(this).is(":hidden")?"show":"hide"]()})},slideDown:function(speed,callback){return this.animate({height:"show"},speed,callback)},slideUp:function(speed,callback){return this.animate({height:"hide"},speed,callback)},slideToggle:function(speed,callback){return this.animate({height:"toggle"},speed,callback)},fadeIn:function(speed,callback){return this.animate({opacity:"show"},speed,callback)
},fadeOut:function(speed,callback){return this.animate({opacity:"hide"},speed,callback)},fadeTo:function(speed,to,callback){return this.animate({opacity:to},speed,callback)},animate:function(prop,speed,easing,callback){var optall=KSQ.speed(speed,easing,callback);return this[optall.queue===false?"each":"queue"](function(){if(this.nodeType!=1)return false;var opt=KSQ.extend({},optall),p,hidden=KSQ(this).is(":hidden"),self=this;for(p in prop){if(prop[p]=="hide"&&hidden||prop[p]=="show"&&!hidden)return opt.complete.call(this);if(p=="height"||p=="width"){opt.display=KSQ.css(this,"display");opt.overflow=this.style.overflow}}if(opt.overflow!=null)this.style.overflow="hidden";opt.curAnim=KSQ.extend({},prop);KSQ.each(prop,function(name,val){var e=new KSQ.fx(self,opt,name);if(/toggle|show|hide/.test(val))e[val=="toggle"?hidden?"show":"hide":val](prop);else{var parts=val.toString().match(/^([+-]=)?([\d+-.]+)(.*)$/),start=e.cur(true)||0;if(parts){var end=parseFloat(parts[2]),unit=parts[3]||"px";if(unit!="px"){self.style[name]=(end||1)+unit;
start=(end||1)/e.cur(true)*start;self.style[name]=start+unit}if(parts[1])end=(parts[1]=="-="?-1:1)*end+start;e.custom(start,end,unit)}else e.custom(start,val,"")}});return true})},queue:function(type,fn){if(KSQ.isFunction(type)||type&&type.constructor==Array){fn=type;type="fx"}if(!type||typeof type=="string"&&!fn)return queue(this[0],type);return this.each(function(){if(fn.constructor==Array)queue(this,type,fn);else{queue(this,type).push(fn);if(queue(this,type).length==1)fn.call(this)}})},stop:function(clearQueue,gotoEnd){var timers=KSQ.timers;if(clearQueue)this.queue([]);this.each(function(){for(var i=timers.length-1;i>=0;i--)if(timers[i].elem==this){if(gotoEnd)timers[i](true);timers.splice(i,1)}});if(!gotoEnd)this.dequeue();return this}});var queue=function(elem,type,array){if(elem){type=type||"fx";var q=KSQ.data(elem,type+"queue");if(!q||array)q=KSQ.data(elem,type+"queue",KSQ.makeArray(array))}return q};KSQ.fn.dequeue=function(type){type=type||"fx";return this.each(function(){var q=queue(this,type);
q.shift();if(q.length)q[0].call(this)})};KSQ.extend({speed:function(speed,easing,fn){var opt=speed&&speed.constructor==Object?speed:{complete:fn||!fn&&easing||KSQ.isFunction(speed)&&speed,duration:speed,easing:fn&&easing||easing&&easing.constructor!=Function&&easing};opt.duration=(opt.duration&&opt.duration.constructor==Number?opt.duration:KSQ.fx.speeds[opt.duration])||KSQ.fx.speeds.def;opt.old=opt.complete;opt.complete=function(){if(opt.queue!==false)KSQ(this).dequeue();if(KSQ.isFunction(opt.old))opt.old.call(this)};return opt},easing:{linear:function(p,n,firstNum,diff){return firstNum+diff*p},swing:function(p,n,firstNum,diff){return(-Math.cos(p*Math.PI)/2+.5)*diff+firstNum}},timers:[],timerId:null,fx:function(elem,options,prop){this.options=options;this.elem=elem;this.prop=prop;if(!options.orig)options.orig={}}});KSQ.fx.prototype={update:function(){if(this.options.step)this.options.step.call(this.elem,this.now,this);(KSQ.fx.step[this.prop]||KSQ.fx.step._default)(this);if(this.prop=="height"||this.prop=="width")this.elem.style.display="block"
},cur:function(force){if(this.elem[this.prop]!=null&&this.elem.style[this.prop]==null)return this.elem[this.prop];var r=parseFloat(KSQ.css(this.elem,this.prop,force));return r&&r>-1e4?r:parseFloat(KSQ.curCSS(this.elem,this.prop))||0},custom:function(from,to,unit){this.startTime=now();this.start=from;this.end=to;this.unit=unit||this.unit||"px";this.now=this.start;this.pos=this.state=0;this.update();var self=this;function t(gotoEnd){return self.step(gotoEnd)}t.elem=this.elem;KSQ.timers.push(t);if(KSQ.timerId==null){KSQ.timerId=setInterval(function(){var timers=KSQ.timers;for(var i=0;i<timers.length;i++)if(!timers[i]())timers.splice(i--,1);if(!timers.length){clearInterval(KSQ.timerId);KSQ.timerId=null}},13)}},show:function(){this.options.orig[this.prop]=KSQ.attr(this.elem.style,this.prop);this.options.show=true;this.custom(0,this.cur());if(this.prop=="width"||this.prop=="height")this.elem.style[this.prop]="1px";KSQ(this.elem).show()},hide:function(){this.options.orig[this.prop]=KSQ.attr(this.elem.style,this.prop);
this.options.hide=true;this.custom(this.cur(),0)},step:function(gotoEnd){var t=now();if(gotoEnd||t>this.options.duration+this.startTime){this.now=this.end;this.pos=this.state=1;this.update();this.options.curAnim[this.prop]=true;var done=true;for(var i in this.options.curAnim)if(this.options.curAnim[i]!==true)done=false;if(done){if(this.options.display!=null){this.elem.style.overflow=this.options.overflow;this.elem.style.display=this.options.display;if(KSQ.css(this.elem,"display")=="none")this.elem.style.display="block"}if(this.options.hide)this.elem.style.display="none";if(this.options.hide||this.options.show)for(var p in this.options.curAnim)KSQ.attr(this.elem.style,p,this.options.orig[p])}if(done)this.options.complete.call(this.elem);return false}else{var n=t-this.startTime;this.state=n/this.options.duration;this.pos=KSQ.easing[this.options.easing||(KSQ.easing.swing?"swing":"linear")](this.state,n,0,1,this.options.duration);this.now=this.start+(this.end-this.start)*this.pos;this.update()
}return true}};KSQ.extend(KSQ.fx,{speeds:{slow:600,fast:200,def:400},step:{scrollLeft:function(fx){fx.elem.scrollLeft=fx.now},scrollTop:function(fx){fx.elem.scrollTop=fx.now},opacity:function(fx){KSQ.attr(fx.elem.style,"opacity",fx.now)},_default:function(fx){fx.elem.style[fx.prop]=fx.now+fx.unit}}});KSQ.fn.offset=function(){var left=0,top=0,elem=this[0],results;if(elem)with(KSQ.browser){var parent=elem.parentNode,offsetChild=elem,offsetParent=elem.offsetParent,doc=elem.ownerDocument,safari2=safari&&parseInt(version)<522&&!/adobeair/i.test(userAgent),css=KSQ.curCSS,fixed=css(elem,"position")=="fixed";if(elem.getBoundingClientRect){var box=elem.getBoundingClientRect();add(box.left+Math.max(doc.documentElement.scrollLeft,doc.body.scrollLeft),box.top+Math.max(doc.documentElement.scrollTop,doc.body.scrollTop));add(-doc.documentElement.clientLeft,-doc.documentElement.clientTop)}else{add(elem.offsetLeft,elem.offsetTop);while(offsetParent){add(offsetParent.offsetLeft,offsetParent.offsetTop);if(mozilla&&!/^t(able|d|h)$/i.test(offsetParent.tagName)||safari&&!safari2)border(offsetParent);
if(!fixed&&css(offsetParent,"position")=="fixed")fixed=true;offsetChild=/^body$/i.test(offsetParent.tagName)?offsetChild:offsetParent;offsetParent=offsetParent.offsetParent}while(parent&&parent.tagName&&!/^body|html$/i.test(parent.tagName)){if(!/^inline|table.*$/i.test(css(parent,"display")))add(-parent.scrollLeft,-parent.scrollTop);if(mozilla&&css(parent,"overflow")!="visible")border(parent);parent=parent.parentNode}if(safari2&&(fixed||css(offsetChild,"position")=="absolute")||mozilla&&css(offsetChild,"position")!="absolute")add(-doc.body.offsetLeft,-doc.body.offsetTop);if(fixed)add(Math.max(doc.documentElement.scrollLeft,doc.body.scrollLeft),Math.max(doc.documentElement.scrollTop,doc.body.scrollTop))}results={top:top,left:left}}function border(elem){add(KSQ.curCSS(elem,"borderLeftWidth",true),KSQ.curCSS(elem,"borderTopWidth",true))}function add(l,t){left+=parseInt(l,10)||0;top+=parseInt(t,10)||0}return results};KSQ.fn.extend({position:function(){var left=0,top=0,results;if(this[0]){var offsetParent=this.offsetParent(),offset=this.offset(),parentOffset=/^body|html$/i.test(offsetParent[0].tagName)?{top:0,left:0}:offsetParent.offset();
offset.top-=num(this,"marginTop");offset.left-=num(this,"marginLeft");parentOffset.top+=num(offsetParent,"borderTopWidth");parentOffset.left+=num(offsetParent,"borderLeftWidth");results={top:offset.top-parentOffset.top,left:offset.left-parentOffset.left}}return results},offsetParent:function(){var offsetParent=this[0].offsetParent;while(offsetParent&&!/^body|html$/i.test(offsetParent.tagName)&&KSQ.css(offsetParent,"position")=="static")offsetParent=offsetParent.offsetParent;return KSQ(offsetParent)}});KSQ.each(["Left","Top"],function(i,name){var method="scroll"+name;KSQ.fn[method]=function(val){if(!this[0])return;return val!=undefined?this.each(function(){this==window||this==document?window.scrollTo(!i?val:KSQ(window).scrollLeft(),i?val:KSQ(window).scrollTop()):this[method]=val}):this[0]==window||this[0]==document?self[i?"pageYOffset":"pageXOffset"]||KSQ.boxModel&&document.documentElement[method]||document.body[method]:this[0][method]}});KSQ.each(["Height","Width"],function(i,name){var tl=i?"Left":"Top",br=i?"Right":"Bottom";
KSQ.fn["inner"+name]=function(){return this[name.toLowerCase()]()+num(this,"padding"+tl)+num(this,"padding"+br)};KSQ.fn["outer"+name]=function(margin){return this["inner"+name]()+num(this,"border"+tl+"Width")+num(this,"border"+br+"Width")+(margin?num(this,"margin"+tl)+num(this,"margin"+br):0)}})})();/*#<![CDATA[*/
//-ver 1.16.309.1
if(!window.console)window.console={};if(!window.console.log)window.console.log=function(){};function _KeyotiFilterControlInit(control,ksqControlElement,filter,filterTransform){//The DIV holding the filter control
control.ksqControlElement=ksqControlElement;//the underlying filter (KeyotiIntFilter etc)
control.filter=filter;//create the filter control from template
control.ksqControlElement.empty();if(typeof filter.definition.OptionLabelFormat!="undefined"){for(var i=0;i<filter.definition.Options.length;i++){var optVal=filter.getRequestDefinition([filter.definition.Options[i].value]);filter.definition.Options[i].label=String._KeyotiFormat(filter.definition.OptionLabelFormat,optVal[0][0],optVal[0][1])}}else{for(var i=0;i<filter.definition.Options.length;i++)filter.definition.Options[i].label=filter.definition.Options[i].value}control.ksqControlElement.kjson2html(filter.definition,filterTransform);control.isGetLiveDataFromServer=function(){return typeof this.filter.definition.GetLiveDataFromServer!="undefined"&&this.filter.definition.GetLiveDataFromServer.toLowerCase()=="true"}}String._KeyotiFormat=function(format){var args=Array.prototype.slice.call(arguments,1);return format.replace(/{(\d+)}/g,function(match,number){return typeof args[number]!="undefined"?args[number]:match})};//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Calendar Range Control
/*

Calendar filter control
 @constructor
 @this {KeyotiCalendarRangeFilterControl}
 @param {} ksqControlElement KSQ element that will hold this Control

 @param {} filter The underlying filter object, eg. KeyotiIntFilter

*/
function KeyotiCalendarRangeFilterControl(ksqControlElement,filter){/**
    Transform definition for this filter control
    @type {Object}
    */
this.filterTransform={tag:"div",html:'<!--${controlDefinition}-->${Label}<br/><input type="text" class="sew_filterFromDate" size="10" /> to <input type="text" class="sew_filterToDate" size="10" />'};_KeyotiFilterControlInit(this,ksqControlElement,filter,this.filterTransform);var options={changeFirstDay:false,prevText:"<",nextText:">",onSelect:function(dateText){keyotiSearch.onFilterChange()}};if(filter.definition.Options.length>0){if(filter.definition.Options[0].toLowerCase()=="today")options.minDate=Date.now();else options.minDate=KSQ.datepicker.parseDate("yy-mm-dd",filter.definition.Options[0])}if(filter.definition.Options.length==2){if(filter.definition.Options[1].toLowerCase()=="today")options.maxDate="0";else options.maxDate=KSQ.datepicker.parseDate("yy-mm-dd",filter.definition.Options[1])}KSQ(".sew_filterFromDate",filter.control).datepicker(options);KSQ(".sew_filterToDate",filter.control).datepicker(options);/**
    Whether this filter has been used by the user, whether it has been set.
    */
this.isFilterUsed=function(){var fromDate=KSQ.datepicker.formatDate("yy-mm-dd",KSQ(".sew_filterFromDate",this.ksqControlElement).datepicker("getDate"));var toDate=KSQ.datepicker.formatDate("yy-mm-dd",KSQ(".sew_filterToDate",this.ksqControlElement).datepicker("getDate"));return fromDate!=null&&fromDate.length>0||toDate!=null&&toDate.length>0||this.isGetLiveDataFromServer()};/**
    Creates object defining the filter, for use in AJAX request.
    */
this.getRequestFilter=function(){var fromDate=KSQ.datepicker.formatDate("yy-mm-dd",KSQ(".sew_filterFromDate",this.ksqControlElement).datepicker("getDate"));var toDate=KSQ.datepicker.formatDate("yy-mm-dd",KSQ(".sew_filterToDate",this.ksqControlElement).datepicker("getDate"));return{Type:this.filter.definition.Type,Filter:filter.getRequestDefinition([fromDate,toDate]),FieldName:this.filter.definition.FieldName,NeedLiveData:this.isGetLiveDataFromServer()}};/**
    Sets the selected values for the filter Control
    @param {} filter A 'RequestFilter' which holds data about the filter, for sending as JSON

    */
this.setSelectedValues=function(filter){if(typeof filter!="undefined"&&filter!=null){var fromDate=KSQ.datepicker.parseDate("yy-mm-dd",filter.Filter[0][0]);var toDate=KSQ.datepicker.parseDate("yy-mm-dd",filter.Filter[0][1]);KSQ(".sew_filterFromDate",this.ksqControlElement).datepicker("setDate",fromDate);KSQ(".sew_filterToDate",this.ksqControlElement).datepicker("setDate",toDate)}else{//default
KSQ(".sew_filterFromDate",this.ksqControlElement).datepicker("setDate","");KSQ(".sew_filterToDate",this.ksqControlElement).datepicker("setDate","")}};/**
    Not implemented
    */
this.updateWithLiveData=function(dataSample){}}//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Checkboxes Control
/**

Checkbox filter control
 @constructor
 @this {KeyotiCheckboxesFilterControl}
 @param {} ksqControlElement KSQ element that will hold this Control

 @param {} filter The underlying filter object, eg. KeyotiIntFilter

*/
function KeyotiCheckboxesFilterControl(ksqControlElement,filter){/**
	Transform definition for this filter control
	@type {Object}
	*/
this.filterTransform={tag:"div",html:"<!--${controlDefinition}-->${Label}<br/>",children:function(){return kjson2html.transform(this.Options,{tag:"span",html:'<label><input type="checkbox" value="${value}"/>${label}</label><br/>'})}};_KeyotiFilterControlInit(this,ksqControlElement,filter,this.filterTransform);//not working in old IE (8) ksqControlElement.change(function () { keyotiSearch.onFilterChange(); });
ksqControlElement.bind(KSQ.browser.msie?"click":"change",function(e){keyotiSearch.onFilterChange()});/**
    Whether this filter has been used by the user, whether it has been set.
    */
this.isFilterUsed=function(){var o=KSQ("input:checked",this.ksqControlElement);return o!=null&&o.length>0||this.isGetLiveDataFromServer()};/**
    Creates object defining the filter, for use in AJAX request.
    */
this.getRequestFilter=function(){var checkedItems=KSQ("input:checked",this.ksqControlElement);var checkedItemsArray=[];for(var i=0;i<checkedItems.length;i++){checkedItemsArray[i]=checkedItems[i].value}return{Type:this.filter.definition.Type,Filter:this.filter.getRequestDefinition(checkedItemsArray),FieldName:this.filter.definition.FieldName,NeedLiveData:this.isGetLiveDataFromServer()}};/**
    Sets the selected values for the filter Control
    @param {} filter A 'RequestFilter' which holds data about the filter, for sending as JSON

    */
this.setSelectedValues=function(requestFilter){function filterContainsValue(requestFilter,value){for(var i=0;i<requestFilter.Filter.length;i++){if(requestFilter.Filter[i][0]==value)return true}return false}if(typeof requestFilter!="undefined"){var checkedItems=KSQ("input[type=checkbox]",this.ksqControlElement);for(var i=0;i<checkedItems.length;i++){checkedItems[i].checked=requestFilter!=null&&filterContainsValue(requestFilter,checkedItems[i].value)}}};/**
    Updates the Control's options with data from the result set.
    @param {} dataSample The dataSample contains data that the underlying filter can process using its preprocessDataSample function.

    */
this.updateWithLiveData=function(dataSample){var checkedItems=KSQ("input:checked",this.ksqControlElement);if(checkedItems.length==0){//KSQ("label", this.ksqControlElement).remove();
if(typeof this.filter.preprocessDataSample=="function")dataSample=this.filter.preprocessDataSample(dataSample);var newOptions=[];for(var j=0;j<dataSample.length;j++)newOptions[j]={value:dataSample[j]};this.filter.definition.Options=newOptions;_KeyotiFilterControlInit(this,ksqControlElement,this.filter,this.filterTransform)}}}//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Checkboxes INTEGER Control
/**

Checkbox integer range filter control
 @constructor
 @this {KeyotiCheckboxesIntRangeFilterControl}
 @param {} ksqControlElement KSQ element that will hold this Control

 @param {} filter The underlying filter object, eg. KeyotiIntFilter

*/
function KeyotiCheckboxesIntRangeFilterControl(ksqControlElement,filter){this.base=new KeyotiCheckboxesFilterControl(ksqControlElement,filter);/**
	Transform definition for this filter control
	@type {Object}
	*/
this.filterTransform=this.base.filterTransform;this.isFilterUsed=this.base.isFilterUsed;this.getRequestFilter=this.base.getRequestFilter;/**
    Sets the selected values for the filter Control
    @param {} filter A 'RequestFilter' which holds data about the filter, for sending as JSON

    */
this.setSelectedValues=function(requestFilter){function filterContainsValue(requestFilter,value){for(var i=0;i<requestFilter.Filter.length;i++){if(requestFilter.Filter[i][0]+"-"+requestFilter.Filter[i][1]==value)return true}return false}if(typeof requestFilter!="undefined"){var checkedItems=KSQ("input[type=checkbox]",this.ksqControlElement);for(var i=0;i<checkedItems.length;i++){checkedItems[i].checked=requestFilter!=null&&filterContainsValue(requestFilter,checkedItems[i].value)}}};this.filter=this.base.filter;this.ksqControlElement=this.base.ksqControlElement;this.isGetLiveDataFromServer=this.base.isGetLiveDataFromServer;/**

    */
this.isValueInRange=function(val,range){var rangeNums=range.split("-");var valNum=parseInt(val);if(parseInt(rangeNums[0])<=valNum&&valNum<parseInt(rangeNums[1])){return true}else return false};/**
    Updates the Control's options with data from the result set.
    @param {} dataSample The dataSample contains data that the underlying filter can process using its preprocessDataSample function.

    */
this.updateWithLiveData=function(dataSample){var checkedItems=KSQ("input:checked",this.ksqControlElement);if(checkedItems.length==0){if(typeof this.filter.preprocessDataSample=="function")dataSample=this.filter.preprocessDataSample(dataSample);this.filter.definition.Options=this.filter.definition.OriginalOptions.slice();for(var i=0;i<this.filter.definition.Options.length;i++){var found=false;for(var j=0;j<dataSample.length;j++){if(this.isValueInRange(dataSample[j],this.filter.definition.Options[i].value)){found=true}}if(!found){this.base.filter.definition.Options.splice(i,1);i--}}_KeyotiFilterControlInit(this,ksqControlElement,this.base.filter,this.base.filterTransform)}}}//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Checkboxes Control
/**

2 Textbox integer range filter control
 @constructor
 @this {KeyotiTextboxesIntRangeFilterControl}
 @param {} ksqControlElement KSQ element that will hold this Control

 @param {} filter The underlying filter object, eg. KeyotiIntFilter

*/
function KeyotiTextboxesIntRangeFilterControl(ksqControlElement,filter){/**
	Transform definition for this filter control
	@type {Object}
	*/
this.filterTransform={tag:"div",html:'<!--${controlDefinition}-->${Label} <input type="text" size="2" /> - <input type="text" size="2" />'};_KeyotiFilterControlInit(this,ksqControlElement,filter,this.filterTransform);//ksqControlElement.change(function () { keyotiSearch.onFilterChange(); });
ksqControlElement.bind(KSQ.browser.msie?"click":"change",function(e){keyotiSearch.onFilterChange()});/**
    Whether this filter has been used by the user, whether it has been set.
    */
this.isFilterUsed=function(){var o=KSQ("input[type=text]",this.ksqControlElement).val();return o!=null&&o.length>0||this.isGetLiveDataFromServer()};/**
    Creates object defining the filter, for use in AJAX request.
    */
this.getRequestFilter=function(){var checkedItems=KSQ("input[type=text]",this.ksqControlElement);var checkedItemsArray=[];for(var i=0;i<checkedItems.length;i++){//checkedItemsArray[i] = checkedItems[i].nextSibling.nodeValue;
checkedItemsArray[i]=checkedItems[i].value}return{Type:this.filter.definition.Type,Filter:this.filter.getRequestDefinition(checkedItemsArray),FieldName:this.filter.definition.FieldName,NeedLiveData:this.isGetLiveDataFromServer()}};/**
    Sets the selected values for the filter Control
    @param {} filter A 'RequestFilter' which holds data about the filter, for sending as JSON

    */
this.setSelectedValues=function(requestFilter){var checkedItems=KSQ("input[type=text]",this.ksqControlElement);if(requestFilter==null){checkedItems[0].value="";checkedItems[1].value=""}else if(requestFilter.Filter.length>0){checkedItems[0].value=requestFilter.Filter[0][0];checkedItems[1].value=requestFilter.Filter[0][1]}};/**
    Not implemented
    */
this.updateWithLiveData=function(dataSample){}}//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~Dropdown Control
/**

Dropdown filter control, uses a SELECT element
 @constructor
 @this {KeyotiDropdownFilterControl}
 @param {} ksqControlElement KSQ element that will hold this Control

 @param {} filter The underlying filter object, eg. KeyotiIntFilter

*/
function KeyotiDropdownFilterControl(ksqControlElement,filter){/**
	The blank item at the top of the dropdown
	@type {String}
	*/
this.defaultEntry=" ";filter.definition.Options.splice(0,0,this.defaultEntry);//add a blank, 'all' selector
/**
	Transform definition for this filter control
	@type {Object}
	*/
this.filterTransform={tag:"div",html:"<!--${controlDefinition}-->${Label}<br/>",children:function(){return"<select>"+kjson2html.transform(this.Options,{tag:"",html:'<option value="${value}">${value}</option>'})+"</select>"}};_KeyotiFilterControlInit(this,ksqControlElement,filter,this.filterTransform);//ksqControlElement.change(function () { keyotiSearch.onFilterChange(); });
ksqControlElement.bind(KSQ.browser.msie?"click":"change",function(e){keyotiSearch.onFilterChange()});/**
    Whether this filter has been used by the user, whether it has been set.
    */
this.isFilterUsed=function(){var o=KSQ("select",this.ksqControlElement).val();return o!=null&&o.length>0||this.isGetLiveDataFromServer()};/**
    Creates object defining the filter, for use in AJAX request.
    */
this.getRequestFilter=function(){var selectedItem=KSQ("select",this.ksqControlElement).val();return{Type:this.filter.definition.Type,Filter:filter.getRequestDefinition([selectedItem,selectedItem]),FieldName:this.filter.definition.FieldName,NeedLiveData:this.isGetLiveDataFromServer()}};/**
    Sets the selected values for the filter Control
    @param {} filter A 'RequestFilter' which holds data about the filter, for sending as JSON

    */
this.setSelectedValues=function(requestFilter){if(typeof requestFilter!="undefined"&&requestFilter!=null){KSQ("select",this.ksqControlElement).val(requestFilter.Filter[0][0])}else{//default
KSQ("select",this.ksqControlElement).val(this.defaultEntry)}};/**
    Updates the Control's options with data from the result set.
    @param {} dataSample The dataSample contains data that the underlying filter can process using its preprocessDataSample function.

    */
this.updateWithLiveData=function(dataSample){var selectedItem=KSQ("select",this.ksqControlElement).val();var addedSelectedItem=true;var sel=KSQ("select",this.ksqControlElement);if(selectedItem==null||selectedItem.length==0||selectedItem==this.defaultEntry){if(typeof this.filter.preprocessDataSample=="function")dataSample=this.filter.preprocessDataSample(dataSample);KSQ("select option:gt(0)",this.ksqControlElement).remove();addedSelectedItem=false;//no remove
KSQ.each(dataSample,function(key,value){if(value==selectedItem)addedSelectedItem=true;sel.append(KSQ("<option></option>").attr("value",value).text(value))})}if(!addedSelectedItem&&selectedItem!=null&&selectedItem.length>0&&selectedItem!=this.defaultEntry)sel.append(KSQ("<option></option>").attr("value",selectedItem).text(selectedItem));KSQ("select",this.ksqControlElement).val(selectedItem)}}//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
/**

The underlying filter that represents the type of filter the related Control will work on.
 @constructor
 @this {KeyotiIntFilter}
 @param {} definition The definition (eg from server) defining the filter control to show and for which custom data field

*/
function KeyotiIntFilter(definition){/** The definition (eg from server) defining the filter control to show and for which custom data field*/
this.definition=definition;/**
    Returns a definition of the filter suitable for transmission in AJAX requests.
    */
this.getRequestDefinition=function(vals){//if (typeof (vals) == 'string') {
/*  if (vals.length == 1 && vals[0].indexOf('-') > -1)
              vals = vals[0].split('-');
      //}
          return [[vals[0], vals[1]]];
      */
//the request def
var r=[];//for each selected value
for(var i=0;i<vals.length;i++){//if we got a string with a '-' treat it as a range
if(typeof vals[i]=="string"&&vals[i].indexOf("-")>-1)r[r.length]=vals[i].split("-");else{//otherwise treat pairs of vals as ranges
r[r.length]=[];r[r.length-1][0]=vals[i];if(i+1<vals.length)r[r.length-1][1]=vals[++i]}}return r}}/**

The underlying filter that represents the type of filter the related Control will work on.
 @constructor
 @this {KeyotiDateFilter}
 @param {} definition The definition (eg from server) defining the filter control to show and for which custom data field

*/
function KeyotiDateFilter(definition){this.definition=definition;/**
    Returns a definition of the filter suitable for transmission in AJAX requests.
    */
this.getRequestDefinition=function(dates){return[[dates[0],dates[1]]]}}/**

The underlying filter that represents the type of filter the related Control will work on.
 @constructor
 @this {KeyotiStringFilter}
 @param {} definition The definition (eg from server) defining the filter control to show and for which custom data field

*/
function KeyotiStringFilter(definition){this.definition=definition;/**
    Returns a definition of the filter suitable for transmission in AJAX requests.
    */
this.getRequestDefinition=function(vals){for(var i=0;i<vals.length;i++)vals[i]=[vals[i]];return vals}}/**

The underlying filter that represents the type of filter the related Control will work on.
 @constructor
 @this {KeyotiStringListFilter}
 @param {} definition The definition (eg from server) defining the filter control to show and for which custom data field

*/
function KeyotiStringListFilter(definition){this.definition=definition;/**
    Returns a definition of the filter suitable for transmission in AJAX requests.
    */
this.getRequestDefinition=function(vals){for(var i=0;i<vals.length;i++)vals[i]=[vals[i]];return vals};/**

    */
this.preprocessDataSample=function(dataSample){//take comma'd items and put in the list
var newData=[];for(var i=0;i<dataSample.length;i++){var data=dataSample[i].split(",");for(var j=0;j<data.length;j++){newData[newData.length]=data[j]}}//deduplicate
newData.sort();for(var i=1;i<newData.length;i++){if(newData[i-1]==newData[i]){newData.splice(i,1);i--}}return newData}}/**
Handles result sorting based on Custom Data.
@namespace
*/
var keyotiCustomDataSort={/**
	* The text to use for 'relevance' sort by option
	*@type {String}
	*/
relevanceText:"Relevance",/**
	*Meta information read from definition comment in the HTML
	*@type {Object}
	*/
meta:null,/**
	*The selected sort by option
	*@type {String}
	*/
selectedSortBy:null,/**
    *Read meta data about data sort control from JSON comment.
    */
init:function(){var controls=KSQ("#sew_sortControl");//KSQ('.sew_dateFilter');
if(controls.length>0){var ctrlDef=controls[0].innerHTML.substring(controls[0].innerHTML.indexOf("{"),controls[0].innerHTML.lastIndexOf("}",controls[0].innerHTML.indexOf("-->"))+1);this.meta=JSON.parse(ctrlDef)}},/**
   *Create child controls (SELECT element)
       */
createChildControls:function(){var controls=KSQ("#sew_sortControl");if(controls.length>0){if(this.meta!=null&&this.meta.Options.length>0){if(this.meta.RelevanceText!=null)this.relevanceText=this.meta.RelevanceText;var sel="<select class='sew_sortControl'>";sel+='<option value="Relevance">'+this.relevanceText+"</option>";for(var i=0;i<this.meta.Options.length;i++){sel+='<option value="'+this.meta.Options[i].Type+"|"+this.meta.Options[i].Direction+"|"+this.meta.Options[i].Field+'">'+this.meta.Options[i].Label+"</option>"}sel+="</select>";controls.html(sel);if(this.selectedSortBy!=null)this.setSortBy(this.selectedSortBy);else this.setSortBy("Relevance");//
if(KSQ.browser.msie){controls.click(function(){if(keyotiCustomDataSort.selectedSortBy!=keyotiCustomDataSort.getSortBy())keyotiSearch.onSortChange()})}else{controls.change(function(){keyotiSearch.onSortChange()})}}}},/**
    *Gets the selected value from the SELECT element.
    */
getSortBy:function(){var o=KSQ("#sew_sortControl>select");if(o.length==0)return this.selectedSortBy;else return o.val()},/**
    Sets the selected value of the SELECT element.
    */
setSortBy:function(v){this.selectedSortBy=v;KSQ("#sew_sortControl>select").val(v)}};/**
Singleton that manages the Custom Data filters.
@namespace
*/
var keyotiCustomDataFilters={//filter controls
/**
	Array of filter controls in use on the page
	@type {Array}
	*/
activeFilters:[],//the definition (eg from server) defining the filter control to show and for which custom data field.  These fields are used by JSON templates in controls above
/*   availableFilterDefinitions: [
                       { Type: 'date', options: ['2000-01-01', '2014-01-01'], FieldName: 'manufacturedDate', Label: null },
                       { Type: 'date', options: ['2000-01-01', '2014-01-01'], FieldName: 'testDriveDate', Label: null },
                       { Type: 'stringor', options: [{ value: 'Ford' }, { value: 'Toyota' }, { value: 'Volkswagon' }], FieldName: 'make', Label: null },
                       { Type: 'int', options: [{ value: 1979 }, { value: 1980 }, { value: 1987 }, { value: 2010 }, { value: 2013 }, { value: 2014 }], FieldName: 'modelYear', Label: null }
       ],
       */
/**
    Initialize, look for sew_filterControl DIVs and read their definitions.
    */
init:function(){var filterDefinitions=null;//availableFilters;//this.getAvailableFilterDefinitions();
var filterDefinition;this.activeFilters=[];var controls=KSQ("div.sew_filterControl");//KSQ('.sew_dateFilter');
for(var i=0;i<controls.length;i++){var ctrlDef=controls[i].innerHTML.substring(controls[i].innerHTML.indexOf("{"),controls[i].innerHTML.lastIndexOf("}",controls[i].innerHTML.indexOf("-->"))+1);var meta=JSON.parse(ctrlDef);var control;if(filterDefinitions==null){//get definition from meta
filterDefinition=meta}else{for(var i=0;i<filterDefinitions.length;i++){if(filterDefinitions[i].FieldName==fieldName){filterDefinition=filterDefinitions[i]}}}if(meta!=null){var filter=this.createFilter(filterDefinition);if(filter!=null){filter.definition.Label=meta.Label;filter.definition.controlDefinition=ctrlDef;filter.definition.OriginalOptions=filter.definition.Options.slice();if(meta.ControlType=="calendar"){control=new KeyotiCalendarRangeFilterControl(KSQ(controls[i]),filter)}else if(meta.ControlType=="checkboxes"){control=new KeyotiCheckboxesFilterControl(KSQ(controls[i]),filter)}else if(meta.ControlType=="checkboxesIntRange"){control=new KeyotiCheckboxesIntRangeFilterControl(KSQ(controls[i]),filter)}else if(meta.ControlType=="textboxesIntRange"){control=new KeyotiTextboxesIntRangeFilterControl(KSQ(controls[i]),filter)}else if(meta.ControlType=="dropdown"){control=new KeyotiDropdownFilterControl(KSQ(controls[i]),filter)}this.activeFilters[this.activeFilters.length]=control}}}},/**
    Gets the filter control being used for the Custom Data field
    @param {} fieldName The Custom Data field name

    */
getFilterControl:function(fieldName){for(var i=0;i<this.activeFilters.length;i++){if(this.activeFilters[i]!=null&&this.activeFilters[i].filter.definition.FieldName==fieldName){return this.activeFilters[i]}}return null},/**
    Updates all filter Controls with live data samples.
    */
updateWithLiveDataSamples:function(dataSamples){for(var i=0;i<dataSamples.length;i++){var filterCtrl=this.getFilterControl(dataSamples[i].FieldName);filterCtrl.updateWithLiveData(dataSamples[i].DataSample)}},/**
    Creates an underlying filter object based on the filterDefinition.
    */
createFilter:function(filterDefinition){if(filterDefinition.Type=="date"){return new KeyotiDateFilter(filterDefinition)}else if(filterDefinition.Type=="int"){return new KeyotiIntFilter(filterDefinition)}else if(filterDefinition.Type=="stringor"){return new KeyotiStringFilter(filterDefinition)}else if(filterDefinition.Type=="stringlistor"){return new KeyotiStringListFilter(filterDefinition)}else if(filterDefinition.Type=="stringlistand"){return new KeyotiStringListFilter(filterDefinition)}},/**
    Gets a collection of request filter definitions from all filter Controls
    */
getRequestFilterCollection:function(){var collection=[];for(var i=0;i<this.activeFilters.length;i++){if(this.activeFilters[i]!=null&&this.activeFilters[i].isFilterUsed()){collection[collection.length]=this.activeFilters[i].getRequestFilter()}}return collection},/**
    Resets all filters to no selection
    */
resetFilterCollection:function(){for(var i=0;i<this.activeFilters.length;i++){this.activeFilters[i].setSelectedValues(null)}},/**
    Sets the current filter collection
    */
setFilterCollection:function(availableFilters){function getFilter(fieldName,availableFilters){for(var i=0;i<availableFilters.length;i++){if(fieldName==availableFilters[i].FieldName)return availableFilters[i]}}for(var i=0;i<this.activeFilters.length;i++){this.activeFilters[i].setSelectedValues(getFilter(this.activeFilters[i].filter.definition.FieldName,availableFilters))}}};/**
Singleton that helps with templating.
@namespace
*/
var keyotiTemplateUtility={/**
    Returns a string equal to customDataDictionaryItemName+"NoContent" if 'value' has zero length, otherwise returns customDataDictionaryItemName+"Content".  This can be overridden with custom logic to return CSS class names based on Custom Data field content
    */
getDisplayClass:function(customDataDictionaryItemName,value){if(value==null||value.length==0)return customDataDictionaryItemName+"NoContent";else return customDataDictionaryItemName+"Content"},/**
    When overridden can be used to format how CustomData value's appear in the search results.  This function implementation only returns 'value'.
    */
formatCustomData:function(customDataDictionaryItemName,value){return value},/**
	Whether to convert data-* style attributes in template elements to *
	@type {Boolean}
	*/
convertDataAttributeInTemplate:true,/**
    Reads the inner HTML template that may be specified for templatable Controls.
    */
readTemplate:function(transform,templateElementId,transformSubItem){var targTransform;if(typeof transformSubItem=="undefined")targTransform=transform;else targTransform=transformSubItem;var obj=KSQ("#"+templateElementId);if(obj!=null&&obj.length>0){transform.tag=obj[0].nodeName;targTransform.html=obj.html();//this is useful when extra attributes are placed in the TEMPLATE tag itself, so they get relayed to the generated element eg. <select id="sew_contentOptionTEMPLATE" multiple="multiple" size="5">
for(var propertyName in obj.getAttributes()){if(propertyName.toLowerCase()!="id")transform[propertyName]=obj[0].getAttribute(propertyName)}if(this.convertDataAttributeInTemplate)targTransform.html=targTransform.html.replace(/data-([^'"]*['"][^'"]*['"])/gi,"data-$1 $1 ");obj.hide()}}};/**
Singleton that handles the search cloud Control.
@namespace
*/
var keyotiSearchCloud={/**
	The maximum number of cloud queries to retrieve from the server
	@type {Number}
	*/
numberOfQueriesToGet:10,/**
	The font size units to use, per CSS
	@type {String}
	*/
fontSizeUnits:"em",/**
	The smallest font size for least searched query
	@type {Number}
	*/
minimumFontSize:.8,/**
	The largest font size for the most search query
	@type {Number}
	*/
maximumFontSize:1.8,/**
	Transform to use to generate cloud query links
	@type {Object}
	*/
itemTransform:{tag:"span","class":"sew_searchCloudItem",style:"${FontSizeStyle}",html:'<a href="#stayhere" onclick="keyotiSearchBox.doSearch(\'${QueryEscaped}\', 1)">${Query}</a> '},/**
	Transform to use to generate cloud box
	@type {Object}
	*/
transform:{tag:"span","class":"sew_searchCloud",html:"",children:function(){return kjson2html.transform(this.Items,keyotiSearchCloud.itemTransform)}},/**
    Initialize the control.
    */
init:function(){keyotiTemplateUtility.readTemplate(keyotiSearchCloud.itemTransform,"sew_searchCloudItemTEMPLATE");keyotiSearchCloud.isEnabled=KSQ("#sew_searchCloudControl").length>0},/**
    Create cloud items based on server data
    */
createChildControls:function(data){if(data.Exception!=null){keyotiResultViewer.onError({Message:data.Exception,StackTrace:""})}else{}var highestTally=0;for(var i=0;i<data.Items.length;i++){if(data.Items[i].Tally>highestTally)highestTally=data.Items[i].Tally}//set normalized frq., and add escaped query
for(var i=0;i<data.Items.length;i++){data.Items[i].QueryEscaped=data.Items[i].Query.replace(/\\/g,"\\\\").replace(/'/g,"\\'");data.Items[i].Frequency=data.Items[i].Tally/highestTally;var fontSize=keyotiSearchCloud.maximumFontSize*data.Items[i].Frequency;if(fontSize<keyotiSearchCloud.minimumFontSize)fontSize=keyotiSearchCloud.minimumFontSize;data.Items[i].FontSize=fontSize;data.Items[i].FontSizeStyle="font-size: "+fontSize+keyotiSearchCloud.fontSizeUnits}keyotiSearchCloud.createControl(data)},/**
    Create content.
    */
createControl:function(data){KSQ("#sew_searchCloudControl").empty();KSQ("#sew_searchCloudControl").kjson2html(data,this.transform);KSQ("#sew_searchCloudControl").css("visibility","visible")}};/**
Singleton that helps with location and content category chooser Controls
@namespace
*/
var keyotiCategoryChoosers={//Location --------------------------------------------------------
/**
	The selected location
	@type {String}
	*/
selectedLocation:null,/**
	The transform to use to generate the location chooser control
	@type {Object}
	*/
locationChooserTransform:{// tag: 'div', 'class': "sew_locationOption", html: '<input type="radio" name="sew_locationOption" id="sew_locationOption${Id}" value="${Value}"/><label for="sew_locationOption${Id}">${Value}</label>'
tag:"div","class":"sew_locationOption",html:"",children:function(){return kjson2html.transform(this.LocationCategories,keyotiCategoryChoosers.locationChooserItemTransform)}},/**
	The transform to use to generate the location chooser control items
	@type {Object}
	*/
locationChooserItemTransform:{tag:"span",html:'<label ><input type="radio" name="sew_locationOption" class="sew_locationOptionItem"  value="${Value}"/>${Value}</label>'},//Read templates
/**
    Initialize
    */
init:function(){keyotiTemplateUtility.readTemplate(this.locationChooserTransform,"sew_locationOptionTEMPLATE",this.locationChooserItemTransform);keyotiTemplateUtility.readTemplate(this.contentChooserTransform,"sew_contentOptionTEMPLATE",this.contentChooserItemTransform)},//Returns backend name for selection
/**
    Gets the selected location category name.  This returns the location 'backend' name, the name used in the index, and not any converted 'frontend' name.
    */
getSelectedLocation:function(){return this.convertLocationBackendNameToFrontEndName(this.selectedLocation,true)},//Sets the selection, where location is the frontend name
/**
    Sets the selected location category name.  This expects the location 'frontend' name, which is returned by convertLocationBackendNameToFrontEndName.
    */
setSelectedLocation:function(location){this.selectedLocation=this.convertLocationBackendNameToFrontEndName(location,false);var locationOptions=KSQ("#sew_locationChooserControl .sew_locationOptionItem");//document.getElementsByName('sew_locationOption');
for(var i=0;i<locationOptions.length;i++){if(locationOptions[i].value==this.selectedLocation){if(typeof locationOptions[i].checked!="undefined")locationOptions[i].checked=true;if(typeof locationOptions[i].selected!="undefined")locationOptions[i].selected=true}}},//Set this member to a function that will receive the locationName (from the index) and return user friendly text (or viceversa if convertBack is set true).
/**
    Converts the location 'backend' name to a 'frontend' name, the backend name is that used in the index, and the frontend name is that used in the UI.  By default they are the same.
    */
convertLocationBackendNameToFrontEndName:function(locationName,convertBack){return locationName},//Set this member to a function that will receive the contentName (from the index) and return user friendly text (or viceversa if convertBack is set true).
/**
    Converts the content 'backend' name to a 'frontend' name, the backend name is that used in the index, and the frontend name is that used in the UI.  By default they are the same.
    */
convertContentBackendNameToFrontEndName:function(contentName,convertBack){return contentName},/**
    Creates location chooser controls
    */
createLocationControls:function(data){KSQ("#sew_locationChooserControl").empty();if(data.CategoriesEnabled){for(var i=0;i<data.LocationCategories.length;i++)data.LocationCategories[i].Value=this.convertLocationBackendNameToFrontEndName(data.LocationCategories[i].Value);KSQ("#sew_locationChooserControl").kjson2html(data,this.locationChooserTransform);KSQ("#sew_locationChooserControl input,#sew_locationChooserControl select").change(function(e){keyotiCategoryChoosers.selectedLocation=e.target?e.target.value:e.srcElement.value;keyotiSearch.onLocationChange(e.target?e.target.value:e.srcElement.value)});if(this.selectedLocation!=null)//now controls have been created we can set them correctly
this.setSelectedLocation(this.convertLocationBackendNameToFrontEndName(this.selectedLocation));else this.setSelectedLocation(this.convertLocationBackendNameToFrontEndName("All"));KSQ("#sew_locationChooserControl").css("visibility","visible")}},//Content --------------------------------------------------------
//Front end names
/**
	The selected content categories
	@type {Array}
	*/
selectedContents:[],/**
	The transform to use to generate the content chooser control
	@type {Object}
	*/
contentChooserTransform:{// tag: 'div', 'class': "sew_locationOption", html: '<input type="radio" name="sew_locationOption" id="sew_locationOption${Id}" value="${Value}"/><label for="sew_locationOption${Id}">${Value}</label>'
tag:"div","class":"sew_contentOption",html:"",children:function(){return kjson2html.transform(this.ContentCategories,keyotiCategoryChoosers.contentChooserItemTransform)}},/**
	The transform to use to generate the content chooser control items
	@type {Object}
	*/
contentChooserItemTransform:{tag:"span",html:'<label ><input type="checkbox" class="sew_contentOptionItem"  value="${Value}"/>${Value}</label>'},//Returns backend names of selected contents
/**
    Gets the selected content category name.  This returns the content 'backend' name, the name used in the index, and not any converted 'frontend' name.
    */
getSelectedContents:function(){if(this.selectedContents.length==0&&!keyotiSearch.useWCFService)this.selectedContents=[this.convertContentBackendNameToFrontEndName("All")];//due to how jquery formats empty arrays for form POSTs (application/x-www-form-urlencoded), we need to make sure no params are empty arrays as they are not sent to the server
var converted=[];for(var i=0;i<this.selectedContents.length;i++)converted[i]=this.convertContentBackendNameToFrontEndName(this.selectedContents[i],true);return converted},//There are 2 versions of the category names, the backend name (index) and frontend name (view)
//contents is 'frontend' names array
/**
    Sets the selected content category names.  This expects the content 'frontend' names, which is returned by convertContentBackendNameToFrontEndName.
    */
setSelectedContents:function(contents){if(typeof contents=="undefined"||contents==null)contents=["All"];this.selectedContents=contents;//convert to backend names
for(var i=0;i<this.selectedContents.length;i++)this.selectedContents[i]=this.convertContentBackendNameToFrontEndName(this.selectedContents[i]);var contentOptions=KSQ("#sew_contentChooserControl .sew_contentOptionItem");//document.getElementsByName('sew_contentOption');
for(var i=0;i<contentOptions.length;i++){if(typeof contentOptions[i].checked!="undefined")contentOptions[i].checked=arrayContains(contents,contentOptions[i].value);// /*|| contents.length == 0 || arrayContains(contents, 'All')*/) {
if(typeof contentOptions[i].selected!="undefined")contentOptions[i].selected=arrayContains(contents,contentOptions[i].value)}function arrayContains(array,target){for(var i=0;i<array.length;i++){if(array[i]==target)return true}}},/**
    Creates content chooser controls
    */
createContentControls:function(data){KSQ("#sew_contentChooserControl").empty();if(data.CategoriesEnabled){for(var i=0;i<data.ContentCategories.length;i++)data.ContentCategories[i].Value=this.convertContentBackendNameToFrontEndName(data.ContentCategories[i].Value);KSQ("#sew_contentChooserControl").kjson2html(data,this.contentChooserTransform);KSQ("#sew_contentChooserControl input,#sew_contentChooserControl select").change(function(e){//keyotiCategoryChoosers.selectedContents = e.srcElement.value;
var contentOptions=KSQ("#sew_contentChooserControl .sew_contentOptionItem");//document.getElementsByName('sew_contentOption');
keyotiCategoryChoosers.selectedContents=[];for(var i=0;i<contentOptions.length;i++){if(contentOptions[i].checked||contentOptions[i].selected){keyotiCategoryChoosers.selectedContents[keyotiCategoryChoosers.selectedContents.length]=contentOptions[i].value}}keyotiSearch.onContentChange(keyotiCategoryChoosers.selectedContents)});if(this.selectedContents!=null)//now controls have been created we can set them correctly
this.setSelectedContents(this.selectedContents);else this.setSelectedContents(["All"]);KSQ("#sew_contentChooserControl").css("visibility","visible")}},//Combined--------------------------------------------------------
//Create child controls based on server data
/**
    Creates location and content controls
    */
createChildControls:function(data){if(data.Exception!=null){keyotiResultViewer.onError({Message:data.Exception,StackTrace:""})}else{keyotiCategoryChoosers.createLocationControls(data);keyotiCategoryChoosers.createContentControls(data);keyotiSearch.onCategoryControlsCreated(data)}}};/**
Manages the search box Control where the user can enter their query
@namespace
*/
var keyotiSearchBox={/**
	Whether to run the search when the user presses ENTER in the query textbox (default true).
	@type {Boolean}
	*/
searchOnEnter:true,/**
	The sew_searchBoxControl element
	@type {Object}
	*/
searchBoxControl:null,/**
	The textbox element
	@type {Object}
	*/
searchBox:null,/**
	The search button element
	@type {Object}
	*/
searchButton:null,/**
	Whether to show the 'Search' placeholder ('watermark')
	@type {Boolean}
	*/
watermarkVisible:true,/**
	The watermark text
	@type {String}
	*/
watermarkText:"Search",/**
	The button text
	@type {String}
	*/
buttonText:"Search",/**
	Optional - when set, searches are sent to the URL set here.  Setting this enables 2 page style searching, otherwise the search results are shown on the same page
	@type {String}
	*/
resultURL:null,//Create child controls and setup event handlers
/**
    Initialize
    */
init:function(){if(this.searchBoxControl==null)this.searchBoxControl=KSQ("#sew_searchBoxControl");if(this.searchBoxControl.length>0){this.ensureSearchBoxChildControls();if(keyotiSearchAutocomplete)keyotiSearchAutocomplete.init();this.searchBox.keydown(function(e){if(e.keyCode==13&&keyotiSearchBox.searchOnEnter){keyotiSearchBox.doSearch();e.preventDefault()}});if(this.watermarkVisible){KSQ("#sew_searchBox").val(this.watermarkText).addClass("sew_watermark");//if blur and no value inside, set watermark text and class again.
KSQ("#sew_searchBox").blur(function(){if(KSQ(this).val().length==0){KSQ(this).val(keyotiSearchBox.watermarkText).addClass("sew_watermark")}});//if focus and text is watermrk, set it to empty and remove the watermark class
KSQ("#sew_searchBox").focus(function(){if(KSQ(this).val()==keyotiSearchBox.watermarkText){KSQ(this).val("").removeClass("sew_watermark")}})}}},/**
    Runs a search with either 'optionalQuery' or if not specified the query in the textbox
    */
doSearch:function(optionalQuery){if(typeof optionalQuery!="string")optionalQuery=keyotiSearchBox.getQuery();keyotiSearch.search(optionalQuery,1)},/**
    Sets the query shown in the textbox
    */
setQuery:function(queryText){KSQ("#sew_searchBox").val(queryText).removeClass("sew_watermark")},/**
    Returns the query in the textbox
    */
getQuery:function(){if(KSQ("#sew_searchBox").hasClass("sew_watermark"))this.setQuery("");return KSQ("#sew_searchBox")[0].value},/**
    Create textbox and button controls if not already present, within an element with id='sew_searchBox'
    */
ensureSearchBoxChildControls:function(){this.searchBox=KSQ("#sew_searchBox");if(this.searchBox.length==0){//create
var searchBoxEl=document.createElement("input");searchBoxEl.setAttribute("type","text");searchBoxEl.setAttribute("id","sew_searchBox");this.searchBoxControl[0].appendChild(searchBoxEl);this.searchBox=KSQ("#sew_searchBox")}this.searchButton=KSQ("#sew_searchButton");if(this.searchButton.length==0){//create
var searchButtonEl=document.createElement("input");searchButtonEl.setAttribute("type","button");searchButtonEl.setAttribute("id","sew_searchButton");searchButtonEl.setAttribute("value",this.buttonText);this.searchBoxControl[0].appendChild(searchButtonEl);this.searchButton=KSQ("#sew_searchButton");this.searchButton.click(keyotiSearchBox.doSearch)}}};/**
Singleton that runs searches and display results
@namespace
*/
var keyotiSearch={_edition:0,/**
    Whether to highlight exact keyword matches in the result document, works with HTML based documents that have imported the SearchUnit_Highlighter.js script.
    @type {Boolean}
    */
highlightKeywordsInResultDocument:true,/**
	The URL to the folder where search engine scripts (eg. SearchUnit.js) are kept (no trailing slash required)
	@type {String}
	*/
commonFolderUrl:"/Keyoti_SearchEngine_Web_Common",/**
	Whether to use WCF to communicate with the server, this is only usable if the application is running under .NET 4+ on the server
	@type {Boolean}
	*/
useWCFService:true,/**
	Whether to update search results as soon as any search options (categories, filters, sort-by) are changed, if this is false it is necessary to call keyotiSearch.showPage(1, true) to trigger a refresh
	@type {Boolean}
	*/
updateOnOptionChange:true,/**
    The query string parameter name to use when linking to results, this is for the highlighter functionality (default=searchunitkeywords).
    @type {String}
    */
resultKeywordParameterName:"searchunitkeywords",/**
	The index directory to search
	@type {String}
	*/
indexDirectory:"~/Keyoti_Search_Index",/**
	The language of the text that is being searched, this affects spell checking: Danish, Dutch, English, EnglishAustralia, EnglishCanada, EnglishMedical, EnglishUK, EnglishUS, French, German, Italian, Norwegian, Polish, Portuguese, Spanish, SpanishLatinAmerica, Swedish, Russian, Custom.
	@type {String}
	*/
language:"",/**
	Path to a custom dictionary, this is relative to the indexDirectory\Dictionaries\ folder (ie specify a filename here and put a text file with that name in the Dictionaries folder under the index directory)
	@type {String}
	*/
customDictionaryPath:"",/**
	Where the spelling suggestions will be sourced, options are defined in the Keyoti.SearchEngine.Suggestions.SpellingSuggestionSource enum (eg. FromEventOnly, PresetDictionary, SearchLexicon, PresetDictionaryAndOptionalSearchLexicon, PresetDictionaryAndSearchLexicon).  Care should be taken with lexicon based options as large lexicons can cause slow downs.
	@type {String}
	*/
spellingSuggestionSource:"PresetDictionary",/**
	The current result page number
	@type {Number}
	*/
pageNumber:1,/**
	The current search query, may be null
	@type {String}
	*/
query:null,/**
	String array of individual keywords in the query
	@type {Array}
	*/
queryKeywords:[],/**
	Number of results to show per page
	@type {Number}
	*/
resultsPerPage:10,/**
	HTML to use to highlight keyword highlights, default is &lt;span class='sew_resultHighlight'&gt;{0}&lt;/span&gt;
	@type {String}
	*/
keywordHighlightPattern:"<span class='sew_resultHighlight'>{0}</span>",/**
	Array of encrypted security group names that the user can search with-in, see the Help topic on Security Groups for information
	@type {Array}
	*/
securityGroups:[],/**
    Called when the chosen location category changes
    */
onLocationChange:function(locationName){if(this.query!=null&&this.updateOnOptionChange)this.showPage(1,true)},/**
    Called when the chosen content categories changes
    */
onContentChange:function(contentNames){if(this.query!=null&&this.updateOnOptionChange)this.showPage(1,true)},/**
    Empty function, called when category controls are created, intended to be overridden by user code.
    */
onCategoryControlsCreated:function(data){},/**
    Called when a filter changes
    */
onFilterChange:function(){if(this.query!=null&&this.updateOnOptionChange)this.showPage(1,true)},/**
    Called when the sort order changes
    */
onSortChange:function(){if(this.query!=null&&this.updateOnOptionChange)this.showPage(1,true)},_queryStringParameters:null,/**

    */
_getQueryStringParameters:function(){if(this._queryStringParameters==null){this._queryStringParameters={};if(window.location.search.length>1){this._queryStringParameters=this._parseQueryStringParameters(window.location.search)}else this._queryStringParameters={}}return this._queryStringParameters},/**

    */
_parseQueryStringParameters:function(qs){var params={};for(var aItKey,nKeyId=0,aCouples=qs.substr(1).split("&");nKeyId<aCouples.length;nKeyId++){aItKey=aCouples[nKeyId].split("=");params[decodeURIComponent(aItKey[0])]=aItKey.length>1?decodeURIComponent(aItKey[1]):""}return params},/**

    */
_onDocumentReady:function(){keyotiCategoryChoosers.init();keyotiCustomDataFilters.init();keyotiSearchCloud.init();keyotiResultViewer.init();//must be init'd before anything to do with history
keyotiSearchBox.init();keyotiCustomDataSort.init();keyotiSearch.updateSearchCloud();keyotiSearch.serviceProxy.invoke("GetLocationAndContentCategories",{indexDirectory:keyotiSearch.indexDirectory},keyotiCategoryChoosers.createChildControls,keyotiResultViewer.onError);var History=window.History;// Note: We are using a capital H instead of a lower h
if(History.enabled){// Bind to StateChange Event
History.Adapter.bind(window,"statechange",keyotiSearch._onHistoryStateChange);var state=History.getState();if(state!=null){keyotiSearch._reconstructSearchFromParameters()}}},/**
    Calls the server to obtain search cloud terms, and displays them using createChildControls function
    */
updateSearchCloud:function(){if(keyotiSearchCloud.isEnabled){keyotiSearch.serviceProxy.invoke("GetSearchCloud",{indexDirectory:keyotiSearch.indexDirectory,numberOfQueries:keyotiSearchCloud.numberOfQueriesToGet},keyotiSearchCloud.createChildControls,keyotiResultViewer.onError)}},/**
    Creates the Custom Data sort control
    */
createCustomDataSortControl:function(){keyotiCustomDataSort.createChildControls()},_onHistoryStateChange:function(){var State=History.getState();keyotiSearch._queryStringParameters=null;//Force a refresh
if(State!=null&&State.data!=null&&State.data.resultObject!=null){//The state has the results already loaded, so use them
keyotiSearch.load(State.data);keyotiSearch.presentResults()}else{//We need to reconstruct the results based on the query string
keyotiSearch._reconstructSearchFromParameters()}},/**
    Shows the search results from keyotiSearch.resultObject
    */
presentResults:function(){var customDataDictionaryKeys=[];//get pretty print keywordmap
for(var i=0;i<keyotiSearch.resultObject.Results.length;i++){var mapString="";if(keyotiSearch.resultObject.Results[i].KeywordHitMap!=null){for(var j=0;j<keyotiSearch.resultObject.Results[i].KeywordHitMap.length;j++){mapString+=keyotiSearch.resultObject.Results[i].KeywordHitMap[j].Keyword+"="+keyotiSearch.resultObject.Results[i].KeywordHitMap[j].Hits;if(j<keyotiSearch.resultObject.Results[i].KeywordHitMap.length-1)mapString+=", "}}keyotiSearch.resultObject.Results[i].KeywordHitMap=mapString;//process customdatadictionary to make more helpful
if(typeof keyotiSearch.resultObject.Results[i].CustomDataDictionary!="undefined"){for(var j=0;j<keyotiSearch.resultObject.Results[i].CustomDataDictionary.length;j++){keyotiSearch.resultObject.Results[i].CustomDataDictionary[keyotiSearch.resultObject.Results[i].CustomDataDictionary[j].Name]=keyotiTemplateUtility.formatCustomData(keyotiSearch.resultObject.Results[i].CustomDataDictionary[j].Name,keyotiSearch.resultObject.Results[i].CustomDataDictionary[j].Value)}}}//eg. ${CustomDataDictionary.imgDisplayClass}
//get dictionary key names from the template
var template=keyotiResultViewer.resultItemTransform.html;var regex=/\$\{CustomDataDictionary\.(.*?)DisplayClass\}/gi;while((result=regex.exec(template))!==null){customDataDictionaryKeys[customDataDictionaryKeys.length]=result[1]}//go through keys and set the displaystyle
for(var i=0;i<keyotiSearch.resultObject.Results.length;i++){//process customdatadictionary to make more helpful
if(typeof keyotiSearch.resultObject.Results[i].CustomDataDictionary!="undefined"){for(var j=0;j<customDataDictionaryKeys.length;j++){keyotiSearch.resultObject.Results[i].CustomDataDictionary[customDataDictionaryKeys[j]+"DisplayClass"]=keyotiTemplateUtility.getDisplayClass(customDataDictionaryKeys[j],keyotiSearch.resultObject.Results[i].CustomDataDictionary[customDataDictionaryKeys[j]])}}}this.highlightResultItems(keyotiSearch.resultObject.Results);this._addQueryKeywordsTo(keyotiSearch.resultObject.Results);keyotiResultViewer.showSearchResults(this.getHeaderJSON(),this.resultObject.Results,this.getFooterJSON());if(this.resultObject.SuggestedSearchExpression==null||this.resultObject.SuggestedSearchExpression.length==0)KSQ("#sew_didYouMean").hide();if(this.resultObject.IgnoredWords.length==0)KSQ("#sew_ignoredWords").hide()},_addQueryKeywordsTo:function(resultsJSON){for(var i=0;i<resultsJSON.length;i++){if(this.highlightKeywordsInResultDocument){var getDelim=resultsJSON[i].UriString.indexOf("?")>-1?"&":"?";
resultsJSON[i].UriStringWithKeywords=resultsJSON[i].UriString+getDelim+keyotiSearch.resultKeywordParameterName+"="+encodeURIComponent(keyotiSearch.queryKeywords)}else resultsJSON[i].UriStringWithKeywords=resultsJSON[i].UriString}},/**
    Adds highlight tags around keyword hits
    */
highlightResultItems:function(resultsJSON){for(var i=0;i<resultsJSON.length;i++){resultsJSON[i].Summary=this.highlightText(resultsJSON[i].Summary);resultsJSON[i].Title=this.highlightText(resultsJSON[i].Title)}},/**
    Adds a highlight to text and returns it, the highlight is set in keyotiSearch.keywordHighlightPattern if the highlightPattern argument is not set.
    */
highlightText:function(text,highlightPattern){if(typeof highlightPattern==="undefined")highlightPattern=this.keywordHighlightPattern;//highlight
RegExp.k_escape=function(text){return text.replace(/[-[\]{}()*+?.,\\^$|#\s]/g,"\\$&")};for(var k=0;k<this.queryKeywords.length;k++){if(keyotiSearch.queryKeywords[k].length>0){var regWithBoundary=new RegExp("\\b("+RegExp.k_escape(keyotiSearch.queryKeywords[k])+")\\b","gi");var regNoBoundary=new RegExp("("+RegExp.k_escape(keyotiSearch.queryKeywords[k])+")","gi");if(/\w/.test(keyotiSearch.queryKeywords[k].charAt(0))&&/\w/.test(keyotiSearch.queryKeywords[k].charAt(keyotiSearch.queryKeywords[k].length-1))){//the keyword starts and ends with a word char (otherwise \b boundary wont match)
text=text.replace(regWithBoundary,highlightPattern.replace("{0}","$1"))}else{//no match, because the keyword starts with a non word character (eg + sign)
text=text.replace(regNoBoundary,highlightPattern.replace("{0}","$1"))}}}return text},/**
    Escapes HTML entities
    */
htmlEscape:function(text){return String(text).replace(/&/g,"&amp;").replace(/"/g,"&quot;").replace(/'/g,"&#39;").replace(/</g,"&lt;").replace(/>/g,"&gt;")},/**
    Gets an object containing header information, so that it can be used with a template
    */
getHeaderJSON:function(){var numberOfPages=Math.ceil(this.resultObject.NumberOfResults/this.resultsPerPage);var escapedSuggestionQuery="";if(this.resultObject.IgnoredWords==null)this.resultObject.IgnoredWords=[];if(this.resultObject.SuggestedSearchExpression!=null&&this.resultObject.SuggestedSearchExpression.length>0)escapedSuggestionQuery=this.resultObject.SuggestedSearchExpression.replace(/\\/g,"\\\\").replace(/'/g,"\\'");return{Query:this.htmlEscape(this.query),NumberOfResults:this.resultObject.NumberOfResults,IgnoredWords:this.resultObject.IgnoredWords.toString().replace(/,/g,", "),SuggestedSearchExpression:this.resultObject.SuggestedSearchExpression,SuggestedSearchExpressionEscaped:escapedSuggestionQuery,PageNumber:this.pageNumber,NumberOfPages:numberOfPages}},/**
    Gets an object containing footer information, so that it can be used with a template
    */
getFooterJSON:function(){var numberOfPages=Math.ceil(this.resultObject.NumberOfResults/this.resultsPerPage);return{PageNumber:this.pageNumber,NumberOfPages:numberOfPages,PreviousPageLink:this.pageNumber>1?'<a href="javascript: keyotiSearch.previousPage();">Previous</a>':"",NextPageLink:this.pageNumber<numberOfPages?'<a href="javascript: keyotiSearch.nextPage();">Next</a>':"",PageLinksBlock:this.getPagingLinksBlock(this.pageNumber,numberOfPages)}},/**
    Gets a block of HTML with links to result pages
    */
getPagingLinksBlock:function(pageNumber,numberOfPages){var pageLinksBlock="";var start,end;start=pageNumber-5;end=pageNumber+5;//current page close to the beginning
if(pageNumber<=5){start=1;end=10}//current page close to the end
if(pageNumber>numberOfPages-5){start=pageNumber-5-(numberOfPages-pageNumber);end=numberOfPages}for(var i=start;i<=end;i++){if(i>0&&i<=numberOfPages){if(i==pageNumber)pageLinksBlock+=i+" ";else pageLinksBlock+='<a href="javascript: keyotiSearch.showPage('+i+');">'+i+"</a> "}}return pageLinksBlock},/* ---------------------------------------- Public Methods ------------------------------------------------ */
/**
    Load the controls with data from 'jsonObject'
    */
load:function(jsonObject){this.resultObject=jsonObject.resultObject;this.pageNumber=jsonObject.pageNumber;this.query=jsonObject.query;keyotiCategoryChoosers.setSelectedLocation(jsonObject.location);keyotiCategoryChoosers.setSelectedContents(jsonObject.contents);keyotiCustomDataFilters.setFilterCollection(jsonObject.customDataFilters);keyotiCustomDataSort.setSortBy(jsonObject.sortBy)},/**
	The number of times the search had to be aborted because another search operation was still loading
	@type {Number}
	*/
abortedSearchAttempts:0,/**
    Runs the search and shows the results
    @param {} query The search query

    @param {} pageNumber The result page to show

    @param {} _blockPushStateToHistory Whether to prevent this search being logged in the browser's history

    */
search:function(query,pageNumber,_blockPushStateToHistory){if(this.serviceProxy.isBusy){if(this.abortedSearchAttempts++<90){setTimeout(function(){keyotiSearch.search(query,pageNumber,_blockPushStateToHistory)},500)}else this.abortedSearchAttempts=0;return}else{this.abortedSearchAttempts=0}this.pageNumber=pageNumber||1;this.query=query;if(keyotiSearchBox.resultURL!=null){location.href=keyotiSearchBox.resultURL+keyotiSearch.makeQueryStringForSearchParameters();//(keyotiSearchBox.resultURL.indexOf('?') > -1 ? '&' : '?') + "query=" + encodeURIComponent(optionalQuery);
return}keyotiResultViewer.showResultsLoadingAnim(true);keyotiResultViewer.openResultsControlPanel();this._blockPushStateToHistory=_blockPushStateToHistory;this._doSearch(this._searchCallBackHandler)},_haveAppliedPwrBy:false,_searchCallBackHandler:function(result){keyotiSearch.resultObject=result;keyotiSearch.queryKeywords=result.QueryKeywords;keyotiSearch._edition=result.Edition;if(keyotiSearch._edition===1&&!keyotiResultViewer._haveAppliedPwrBy){keyotiResultViewer._haveAppliedPwrBy=true;KSQ("#sew_searchResultControl").append("Powered by <a href='https://keyoti.com/products/search/dotNetWeb/index.html?utm_source=CommunityInstall&utm_medium=Nag&utm_campaign=SearchUnit'>Keyoti SearchUnit Community Edition</a>")}if(result.LiveDataSamples!=null){keyotiCustomDataFilters.updateWithLiveDataSamples(result.LiveDataSamples)}var wasError=result.Exception!=null;keyotiResultViewer.clearLoadingAnimTimeout();if(wasError){//keyotiResultViewer.showServerError();
//keyotiResultViewer.hideResultsLoadingAnim();
keyotiResultViewer.onError({Message:result.Exception,StackTrace:""})}else{if(!keyotiSearch._blockPushStateToHistory)//pushing the state causes the results to be updated
{//update and rebuild query string
keyotiSearch._pushSearchToHistory()}else{keyotiSearch.presentResults()}keyotiResultViewer.hideResultsLoadingAnim()}keyotiSearch._blockPushStateToHistory=false;keyotiSearch.updateSearchCloud()},/**
    Returns the query string based on search parameters
    */
makeQueryStringForSearchParameters:function(){var queryParams=keyotiSearch._getQueryStringParameters();queryParams.query=encodeURIComponent(keyotiSearch.query);queryParams.pageNumber=keyotiSearch.pageNumber;queryParams.location=encodeURIComponent(keyotiCategoryChoosers.getSelectedLocation());queryParams.contents=encodeURIComponent(keyotiCategoryChoosers.getSelectedContents());queryParams.customDataFilters=encodeURIComponent(JSON.stringify(keyotiCustomDataFilters.getRequestFilterCollection()));queryParams.sortBy=encodeURIComponent(keyotiCustomDataSort.getSortBy());var qs="?";var needAmp=false;for(var param in queryParams){var val=queryParams[param];qs+=(needAmp?"&":"")+param+"="+val;needAmp=true}return qs},_pushSearchToHistory:function(){var qs=keyotiSearch.makeQueryStringForSearchParameters();History.pushState({resultObject:keyotiSearch.resultObject,pageNumber:keyotiSearch.pageNumber,query:keyotiSearch.query,location:keyotiCategoryChoosers.getSelectedLocation(),contents:keyotiCategoryChoosers.getSelectedContents(),customDataFilters:keyotiCustomDataFilters.getRequestFilterCollection(),sortBy:keyotiCustomDataSort.getSortBy()},"Search page "+keyotiSearch.pageNumber,qs)
},_reconstructSearchFromParameters:function(){var oGetVars=keyotiSearch._getQueryStringParameters();if(oGetVars.query!=null){keyotiSearchBox.setQuery(oGetVars.query);keyotiCategoryChoosers.setSelectedLocation(oGetVars.location);keyotiCategoryChoosers.setSelectedContents(oGetVars.contents?oGetVars.contents.split(","):[]);if(typeof oGetVars.customDataFilters!="undefined")keyotiCustomDataFilters.setFilterCollection(JSON.parse(oGetVars.customDataFilters));if(typeof oGetVars.sortBy!="undefined"&&oGetVars.sortBy!="null")keyotiCustomDataSort.setSortBy(oGetVars.sortBy);keyotiSearch.search(oGetVars.query,oGetVars.pageNumber!=null?parseInt(oGetVars.pageNumber):1,true);keyotiResultViewer.openResultsControlPanel(true)}else{keyotiCustomDataFilters.resetFilterCollection();keyotiResultViewer.hideSearchResults(true)}},/**
    Shows the next page of results
    */
nextPage:function(){this.showPage(this.pageNumber+1)},/**
    Shows the previous page of results
    */
previousPage:function(){this.showPage(this.pageNumber-1)},/**
    Shows a result page specified by 'pageNumber'
    @param {} pageNumber The page to show

    @param {} blockScroll Whether to prevent the page scrolling back to the top as the new page of results is shown

    */
showPage:function(pageNumber,blockScroll){if(!blockScroll)keyotiResultViewer.scrollTop();this.pageNumber=pageNumber;keyotiResultViewer.showResultsLoadingAnim(true);this._doSearch(this._searchCallBackHandler)},/**

    */
_doSearch:function(resultsLoadedCallback){this.serviceProxy.invoke("GetResults",{indexDirectory:this.indexDirectory,query:this.query,resultPage:this.pageNumber,resultsPerPage:this.resultsPerPage,locationName:keyotiCategoryChoosers.getSelectedLocation(),contentNames:keyotiCategoryChoosers.getSelectedContents(),securityGroupNames:this.getSecurityGroups(),filterCollection:keyotiCustomDataFilters.getRequestFilterCollection(),sortBy:keyotiCustomDataSort.getSortBy(),language:this.language,customDictionaryPath:this.customDictionaryPath,spellingSuggestionSource:this.spellingSuggestionSource},resultsLoadedCallback,keyotiResultViewer.onError)},/**
    Returns the security groups set by the developer
    */
getSecurityGroups:function(){//we can't return empty array because webservice cannot receive empty arrays
if(this.securityGroups==null||this.securityGroups.length==0)return[""];else return this.securityGroups},// *** Service Calling Proxy Class
/**
    Handles AJAX service calls
    */
serviceProxy:new function(){var _I=this;this.isBusy=false;this.appendURLString="";this.diagnoseWCFProblem=function(){//try get cloud
this.invoke("GetSearchCloud","",null,null,null,"GET")};// *** Call a wrapped object
this.invoke=function(method,data,callback,error,bare,POSTGET){if(typeof POSTGET=="undefined")POSTGET="POST";if(keyotiSearch.useWCFService)this.serviceUrl=keyotiSearch.commonFolderUrl+"/SearchService.svc/";else this.serviceUrl=keyotiSearch.commonFolderUrl+"/SearchWebService.asmx/";this.isBusy=true;// *** The service endpoint URL        
var url=_I.serviceUrl+method+this.appendURLString;if(!keyotiSearch.useWCFService){console.log("Using web service .NET 2");if(typeof data.filterCollection!="undefined")data.filterCollection=JSON.stringify(data.filterCollection);//{ Format: 'f', Field: 'f' };//data.filterCollection[0];
//data.filterCollection.Filter = null;
KSQ.ajax({url:url,data:data,// "indexDirectory=/Keyoti_Search_Index",
type:POSTGET,processData:true,contentType:"application/x-www-form-urlencoded",//; charset=utf-8
timeout:3e4,dataType:"text",// not "json" we'll parse
success:function(res){keyotiSearch.serviceProxy.isBusy=false;if(!callback)return;var firstBrace=res.indexOf("{");var lastBrace=res.lastIndexOf("}");bare=true;var result=null;if(firstBrace>-1&&lastBrace>-1)result=JSON.parse(res.substring(firstBrace,lastBrace+1));// *** Bare message IS result
if(bare){callback(result);return}// *** Wrapped message contains top level object node
// *** strip it off
for(var property in result){/* added this code similarly from RS */
if(result[property].exception!=null&&result[property].exception.length>0){alert(result[property].exception);return}if(result[property].Exception!=null&&result[property].Exception.length>0){alert(result[property].Exception);return}callback(result[property]);break}},error:function(xhr,textstatus,message){keyotiSearch.serviceProxy.isBusy=false;if(!error)return;if(xhr.responseText){var err=xhr.responseText;//JSON.parse(xhr.responseText);
if(err)error({Message:err+"\r\nURL (click to get more error info): <a href='"+this.url+"'>"+this.url+"</a>",StackTrace:""});else error({Message:"Unknown server error.",StackTrace:""})}else if(textstatus){if(textstatus=="timeout")textstatus="Sorry the server has not responded, please try again.";if(textstatus=="error"){if(xhr.status==404){textstatus=xhr.status+' error from server.  \r\nTry calling (in Javascript) \r\n\r\nkeyotiSearch.commonFolderUrl = "/Keyoti_SearchEngine_Web_Common/";\r\n\r\nwith the correct path to the folder that contains SearchService.svc and/or SearchWebService.asmx\r\n'}else textstatus=xhr.status+" error from server."}error({Message:textstatus+"\r\n\r\nURL (click to get more error info): <a href='"+this.url+"'>"+this.url+"</a>",StackTrace:""})}return}})}else{// *** Convert input data into JSON - REQUIRES Json2.js
var json=JSON.stringify(data);console.log("Using WCF service .NET 4");KSQ.ajax({url:url,data:json,type:POSTGET,processData:false,contentType:"application/json",//; charset=utf-8
timeout:3e4,dataType:"text",// not "json" we'll parse
success:function(res){keyotiSearch.serviceProxy.isBusy=false;if(!callback)return;// *** Use json library so we can fix up MS AJAX dates
var result=JSON.parse(res);//bare = true;
// *** Bare message IS result
if(bare){callback(result);return}// *** Wrapped message contains top level object node
// *** strip it off
for(var property in result){callback(result[property]);break}},error:function(xhr,textstatus,message){if(xhr.status==500&&xhr.responseText.length==0){keyotiSearch.serviceProxy.diagnoseWCFProblem()}keyotiSearch.serviceProxy.isBusy=false;if(xhr.responseText.indexOf("Version:2.0")>-1)alert("It appears that you are running .NET 2 on the server, therefore you must call this Javascript in your page:\r\n\r\nkeyotiSearch.useWCFService=true;\r\n\r\nDoing that will use the .NET 2 ASMX Web Service instead of .NET 4 WCF");if(!error)return;if(xhr.responseText){var err;try{err=JSON.parse(xhr.responseText)}catch(ee){err={Message:"URL (click to get more error info): <a href='"+this.url+"'>"+this.url+"</a>"+"\r\n\r\n"+xhr.responseText}}if(err){err.Message+="\r\nURL (click to get more error info): <a href='"+this.url+"'>"+this.url+"</a>";error(err)}else error({Message:"Unknown server error."+"\r\nURL (click to get more error info): <a href='"+this.url+"'>"+this.url+"</a>"})}else if(textstatus){if(textstatus=="timeout")textstatus="Sorry the server has not responded, please try again.";
if(textstatus=="error"){if(xhr.status==404){textstatus=xhr.status+' error from server.  \r\nTry calling (in Javascript) \r\n\r\nkeyotiSearch.commonFolderUrl = "/Keyoti_SearchEngine_Web_Common/";\r\n\r\nwith the correct path to the folder that contains SearchService.svc and/or SearchWebService.asmx\r\n'}else textstatus=xhr.status+" error from server."}error({Message:textstatus+"\r\n\r\nURL (click to get more error info): <a href='"+this.url+"'>"+this.url+"</a>",StackTrace:""})}return}})}}}};/**
Singleton manager of header/list/footer style Control
@namespace
*/
var keyotiResultViewer={/**
	Milliseconds to wait before showing the loading animation (default=10)
	@type {Number}
	*/
showResultsLoadingAnimPause:10,/**
	Internal use
	@type {Number}
	*/
resultControlPanelInitialWidth:-1,/**
	Internal use
	@type {Number}
	*/
resultControlPanelInitialHeight:500,/**
	Milliseconds to animate the result panel animation over (default=300)
	@type {Number}
	*/
resultControlPanelAnimationTime:300,/**
	The timeout reference for the loading animation
	@type {Object}
	*/
showResultsLoadingAnimTimeout:null,/**
	Whether the results panel is open
	@type {Boolean}
	*/
resultsPanelIsOpen:true,/**
	The result panel element
	@type {Object}
	*/
resultControlPanel:null,/**
	The results list panel element
	@type {Object}
	*/
resultListPanel:null,/**
	The result header panel element
	@type {Object}
	*/
resultHeaderPanel:null,/**
	The result footer panel element
	@type {Object}
	*/
resultFooterPanel:null,/**
	The result view panel element
	@type {Object}
	*/
resultViewPanel:null,/**
	The results from the server
	@type {Object}
	*/
resultObject:null,/**
    Creates child controls if necessary
    */
ensureChildControls:function(){var backer=KSQ(".sew_ajax_loader_backer");if(backer.length==0){KSQ("#sew_searchResultControl").append('<div class="sew_ajax_loader_backer"><div class="sew_ajax_loader"></div></div>')}var error=KSQ(".sew_ajax_error");if(error.length==0){KSQ("#sew_searchResultControl").append('<div class="sew_ajax_error"><span class="sew_errorTitle">Error</span><p class="sew_errorBody"></p><div class="sew_ajax_error_footer"><input type="button" value="OK" id="sew_errorOKButton" /></div></div>')}var view=KSQ("#sew_resultView");if(view.length==0){KSQ("#sew_searchResultControl").append('<div id="sew_resultView"><div id="sew_resultHeader"></div><div id="sew_resultList"></div><div id="sew_resultFooter"></div></div>')}},/**
    Called when a server error occurs, and shows the error
    */
onError:function(error){keyotiResultViewer.showServerError(error);keyotiResultViewer.getResultControlPanel().removeClass("loading")},//Read templates from HTML
/**
    Initialize
    */
init:function(){this.ensureChildControls();KSQ("#sew_errorOKButton").click(keyotiResultViewer.onErrorOKButton_Click);//set default templates - need to do this here because reliance on keyotiSearch.commonFolderUrl having been set.
keyotiResultViewer.resultItemTransform={tag:"div","class":"sew_resultItem",html:'                                                                                                                                                                    <span class="sew_resultItemLink"><a href="${UriStringWithKeywords}">${Title}</a></span>                                                                                                         <span class="sew_resultItemSummary">${Summary}</span>                                                                                                                               <span class="sew_previewResultWrapper"><img alt="Click to preview the document text" src="'+keyotiSearch.commonFolderUrl+"/ResultPreview_Expander_Closed.png\"                                            onclick=\"keyotiSearchResultPreviewer.toggleResultPreview(this,                                                                                                                                              '${UriStringAsStored}',                                                                                                                                                   '"+keyotiSearch.commonFolderUrl+"/ResultPreview_Expander_Closed.png',                                                                                                                              '"+keyotiSearch.commonFolderUrl+'/ResultPreview_Expander_Opened.png\')"/>                                                                                                                       <span class="sew_previewResultContent">Loading document...</span></span>                                                                                                            <div style="clear:both; height:1px;"></div>                                                                                                                                             <span class="sew_resultItemURL">${UriString}</span>                                                                                                                                                                                                                                                                   <span class="sew_location">${Location}</span>                                                                                                                                              <span class="sew_location">${Content}</span>                                                                                                                                                                                                                                                                                                                            '};
keyotiResultViewer.resultHeaderTransform={tag:"div",html:'<div class="sew_header">Showing result page <b>${PageNumber}</b>. There are <b>${NumberOfResults}</b> results for <b>&#8220;${Query}&#8221;</b>. <span id="sew_ignoredWords">The following common words were ignored: ${IgnoredWords}</span></div><div id="sew_didYouMean">Did you mean: <a href="#stayhere" onclick="keyotiSearch.search(\'${SuggestedSearchExpressionEscaped}\', 1)">${SuggestedSearchExpression}</a></div>'};keyotiResultViewer.resultFooterTransform={tag:"div",html:'<div class="sew_footer"><span id="previousPageLink">${PreviousPageLink}</span> <span id="pageLinksBlock">${PageLinksBlock}</span><span id="nextPageLink">${NextPageLink}</span></div>'};keyotiTemplateUtility.readTemplate(this.resultItemTransform,"sew_resultItemTEMPLATE");keyotiTemplateUtility.readTemplate(this.resultFooterTransform,"sew_footerTEMPLATE");keyotiTemplateUtility.readTemplate(this.resultHeaderTransform,"sew_headerTEMPLATE")},/**
    Scroll to the the top of the page if topOfPage is true, otherwise to the result header location
    */
scrollTop:function(topOfPage){var target;if(topOfPage)target=0;else target=keyotiResultViewer.getResultControlPanel().offset().top;KSQ("html, body").animate({scrollTop:target},500)},/**
	The result item transform
	@type {Object}
	*/
resultItemTransform:null,/**
	The header transform
	@type {Object}
	*/
resultHeaderTransform:null,/**
	The footer transform
	@type {Object}
	*/
resultFooterTransform:null,/**
    Returns the id=sew_searchResultControl element - which holds the entire search result control
    */
getResultControlPanel:function(){if(this.resultControlPanel==null){this.resultControlPanel=KSQ("#sew_searchResultControl")}return this.resultControlPanel},/**
    Returns the element holding the results section of the control, this is separate to the error and loading DIVs, and contains the sew_resultList element
    */
getResultViewPanel:function(){if(this.resultViewPanel==null){this.resultViewPanel=KSQ("#sew_resultView")}return this.resultViewPanel},/**
    Returns the element holding the 'result list' section of the control (ie between the header or footer)
    */
getResultListPanel:function(){if(this.resultListPanel==null){this.resultListPanel=KSQ("#sew_resultList")}return this.resultListPanel},/**
    Returns the header panel element
    */
getResultHeaderPanel:function(){if(this.resultHeaderPanel==null){this.resultHeaderPanel=KSQ("#sew_resultHeader")}return this.resultHeaderPanel},/**
    Returns the footer panel element
    */
getResultFooterPanel:function(){if(this.resultFooterPanel==null){this.resultFooterPanel=KSQ("#sew_resultFooter")}return this.resultFooterPanel},/**
    Opens the results panel so that it is visible
    @param {} instantly Whether to open the panel immediately or animate it

    */
openResultsControlPanel:function(instantly){if(this.getResultControlPanel().length==0)alert("Search could not find required element with id='sew_searchResultControl', please add <div id='sew_searchResultControl'></div> to your page to display search results");else{if(!this.resultsPanelIsOpen){this.resultsPanelIsOpen=true;if(instantly)this.getResultControlPanel().show();else this.getResultControlPanel().slideToggle(instantly?0:this.resultControlPanelAnimationTime)}}},/**
    Closes the results panel so that it is invisible
    @param {} instantly Whether to close the panel immediately or animate it

    */
closeResultsControlPanel:function(instantly){if(this.resultsPanelIsOpen){this.resultsPanelIsOpen=false;if(instantly)this.getResultControlPanel().hide();else this.getResultControlPanel().slideToggle(instantly?0:this.resultControlPanelAnimationTime)}},/**
    Show the search results, opening the result panel if necessary
    */
showSearchResults:function(headerJSON,resultsJSON,footerJSON){this.openResultsControlPanel();this.getResultListPanel().empty();this.getResultHeaderPanel().empty();this.getResultFooterPanel().empty();this.getResultHeaderPanel().kjson2html(headerJSON,this.resultHeaderTransform);keyotiSearch.createCustomDataSortControl();this.getResultListPanel().kjson2html(resultsJSON,this.resultItemTransform);this.getResultFooterPanel().kjson2html(footerJSON,this.resultFooterTransform);this.hideResultsLoadingAnim();this.expandResultControlPanel()},/**
    Closes the results panel so that it is invisible and empties the child control content
    */
hideSearchResults:function(instant){this.closeResultsControlPanel(instant);this.getResultListPanel().empty();this.getResultHeaderPanel().empty();this.getResultFooterPanel().empty()},_getLicensingError:function(message){//gather details: "License exception:192.168.1.103|work7|Pro|[expiry]|Keyoti4.SearchEngine.Web, Version=2015.6.16.825, Culture=neutral, PublicKeyToken=58d9fd2e9ec4dc0e\r\n
var detailsStr=message.substring(message.indexOf(":")+1,message.indexOf("\r"));var details=detailsStr.split("|");var lm="Sorry, SearchUnit is either not licensed to run on this server or this web site.\n\nPlease double check your license key and ensure it is set in the web.config per the Help.\n\n";lm+="Server name: "+details[1]+"\n";lm+="Server IP: "+details[0]+"\n";lm+="Installed level: "+details[2]+"\n";if(details[3].length>0){lm+=details[3]+"\n"}lm+="Assembly: "+details[4]+"\n";return lm},_getCommunityError:function(message){var lm="Sorry, the search index was not created by the Community/Free License Edition, please install the Community/Free License Edition and recreate the index.\n\nThis restriction is implemented to prevent abuse of the free edition.";return lm},/**
    Displays error information to the user
    @param {} exception Object with Message and StackTrace properties

    */
showServerError:function(exception){if(exception){if(exception.Message.indexOf("License")>-1&&exception.Message.indexOf("|")>-1){exception=this._getLicensingError(exception.Message)}else if(exception.Message.indexOf("Community")>-1){exception=this._getCommunityError(exception.Message)}else exception=exception.Message+" \n"+exception.StackTrace}else if(keyotiSearch.Exception)exception=keyotiSearch.Exception;exception+="\r\n\r\nkeyotiSearch.useWCFService="+keyotiSearch.useWCFService;//if there is a result panel, show result in that otherwise use alert
if(this.getResultControlPanel().length==0){alert(exception.toString())}else{this.openResultsControlPanel(true);exception=exception.replace(/\n/g,"<br />");var targetPlacement=this.getResultControlPanel();// if (targetPlacement.width() == 0) targetPlacement = KSQ("body");
var cpHeight=targetPlacement.height();if(cpHeight<100)//need to push it open
{targetPlacement.height(this.resultControlPanelInitialHeight);cpHeight=this.resultControlPanelInitialHeight}var cpOffset=targetPlacement.offset();var cpWidth=targetPlacement.width();var top=cpHeight/4;if(top<150)top=150;else if(top>700)top=700;//this.clearLoadingAnimTimeout();
this.getResultControlPanel().addClass("error");KSQ(".sew_ajax_error").css({position:"absolute",left:cpWidth/2+"px",top:top+"px","margin-left":-KSQ(".sew_ajax_error").width()/2,"margin-top":-KSQ(".sew_ajax_error").height()/2});KSQ(".sew_errorBody").html(exception)}},/**
    Hides the server error message
    */
hideServerError:function(){this.getResultControlPanel().removeClass("error")},/**
    Handles the error OK button click
    */
onErrorOKButton_Click:function(){keyotiResultViewer.hideServerError()},/**
    Clears the loading animation timeout, usually because the results have been loaded
    */
clearLoadingAnimTimeout:function(){if(this.showResultsLoadingAnimTimeout!=null){//console.log("clearing loading timeout");
clearTimeout(this.showResultsLoadingAnimTimeout)}},/**
    Shows the result loading animation after 'wait' millisconds, unless the results load first
    */
showResultsLoadingAnim:function(wait){this.clearLoadingAnimTimeout();//console.log("set loading timeout");
this.showResultsLoadingAnimTimeout=setTimeout(function(){console.log("showing loading ");keyotiResultViewer.getResultControlPanel().addClass("loading");var cpHeight=keyotiResultViewer.getResultControlPanel().height();if(cpHeight<100)//we're still sliding it open
cpHeight=keyotiResultViewer.resultControlPanelInitialHeight;var cpOffset=keyotiResultViewer.getResultControlPanel().offset();var cpWidth=keyotiResultViewer.getResultControlPanel().width();var sew_ajax_loader_backer=KSQ(".sew_ajax_loader_backer");sew_ajax_loader_backer.css({position:"absolute",left:"0",top:"0",height:cpHeight+"px",width:cpWidth+"px"});var sew_ajax_loader=KSQ(".sew_ajax_loader");sew_ajax_loader.html("<img src='"+keyotiSearch.commonFolderUrl+"/ajax-result-loader.gif' /><br/>Loading...");var top=cpHeight/4;if(top<100)top=100;else if(top>700)top=700;sew_ajax_loader.css({position:"absolute",left:cpWidth/2+"px",top:top+"px",//cpOffset.top ,
height:"100px",width:"200px","margin-left":-200/2+"px","margin-top":-100/2+"px"})},wait?this.showResultsLoadingAnimPause:0)},/**
    Hides the loading animation
    */
hideResultsLoadingAnim:function(){var sew_ajax_loader_backer=KSQ(".sew_ajax_loader_backer");sew_ajax_loader_backer.css({height:"0px",width:"0px"});var sew_ajax_loader=KSQ(".sew_ajax_loader");sew_ajax_loader.css({height:"0px",width:"0px"});this.getResultControlPanel().removeClass("loading")},resultViewPanelWidth:-1,/**
    Expands the result panel to fit the result content inside of it
    @param {} extraHeight Any additional height to add to the content height

    */
expandResultControlPanel:function(extraHeight){var contentWidth;if(this.resultControlPanelInitialWidth==-1){contentWidth=this.getResultViewPanel().width();this.resultControlPanelInitialWidth=contentWidth}else contentWidth=this.resultControlPanelInitialWidth;if(typeof extraHeight=="undefined")extraHeight=0;//var contentHeight = this.getResultListPanel().height() + this.getResultHeaderPanel().height() + this.getResultFooterPanel().height() + extraHeight;
var contentHeight=this.getResultViewPanel().height()+50+extraHeight;this.getResultControlPanel().animate({opacity:1,width:contentWidth,height:contentHeight},this.resultControlPanelAnimationTime)},/**
    Shrinks the result panel by extraHeight
    @param {} extraHeight The amount of height to remove

    */
shrinkResultControlPanel:function(extraHeight){var contentWidth=this.getResultViewPanel().width();if(typeof extraHeight=="undefined")extraHeight=0;var contentHeight=this.getResultControlPanel().height()-extraHeight;this.getResultControlPanel().animate({opacity:1,width:contentWidth,height:contentHeight},this.resultControlPanelAnimationTime)}};/**
Singleton handling query auto-complete
@namespace
*/
var keyotiSearchAutocomplete={/**
	Whether to hide any failure messages
	@type {Boolean}
	*/
sew_failSilent:false,/**
	Whether to filter out filenames from the suggestions
	@type {Boolean}
	*/
filterFilenames:true,/**
	Behavior options
	@type {Object}
	*/
options:{/**
	The ID of the text box where autocomplete suggestions will be shown
	@type {String}
	*/
sew_queryTextBoxID:"sew_searchBox",/**
	The ID of the search button
	@type {String}
	*/
sew_searchButtonID:"btnAdd",/**
	The index directory where suggestions will come from
	@type {String}
	*/
indexDirectory:null,//pathto index dir
/**
	The maximum number of suggestions to show
	@type {String}
	*/
sew_numberOfSuggestions:"5",/**
	Whether to run the search when the user selects a suggestion from the list
	@type {Boolean}
	*/
sew_runSearchOnSelect:true,//this will happen
/**
	Whether to show the estimated number of results for each suggestion
	@type {Boolean}
	*/
sew_showNumberOfResults:false,/*sew_searchPostback: "searchForm.submit();",*/
/*appPath: "/",*/
/**
	Whether to load the plugin during autocomplete queries (default=false), this allows the plugin to affect autocomplete suggestions
	@type {Boolean}
	*/
sew_autoCompleteQueryLoadPlugin:false,/**
	Source of suggestions, see Keyoti.SearchEngine.Web.SearchBox.AutoCompleteSuggestionSource enum for possible options (eg. IndexLexicon, PopularSearches, PopularSearchesAndLexicon)
	@type {String}
	*/
sew_source:"PopularSearchesAndLexicon",/**
	Hide suggestions with no (estimated) results
	@type {Boolean}
	*/
sew_hideNoResulters:false},sew_OC:new Object,sew_queryTB:null,/**
	Autocomplete suggestion drop down X position shift
	@type {Number}
	*/
sew_menuShiftX:0,/**
	Autocomplete suggestion drop down Y position shift
	@type {Number}
	*/
sew_menuShiftY:0,/**

    */
dataReceived:function(data,query){},/**

    */
sew_item_selected:function(li,options){if(keyotiSearchAutocomplete.options.sew_runSearchOnSelect)keyotiSearchBox.doSearch();else keyotiSearchBox.searchBox.focus()},/**

    */
sew_formatItem:function(row,i,num,li){return"<span class='sew_suggestion'>"+row[0].replace(/</g,"&lt;").replace(/>/g,"&gt;")+"</span><span class='sew_results'>"+(row[1]!="-1"&&typeof row[1]!="undefined"?row[1]:"")+"</span>"},/**

    */
init:function(){//for(var i=0; i<sew_configs.length; i++){
//keyotiSearch.serviceProxy.invoke("GetPreviewText", { indexDirectory: "~/Keyoti_Search_Index", u: url, p: (previewLoadPlugin ? 1 : 0), mx: maxCharLength }, function(data) {
KSQ("#"+keyotiSearchAutocomplete.options.sew_queryTextBoxID).autocomplete(null,{delay:50,minChars:1,matchSubset:0,matchContains:1,cacheLength:1,formatItem:keyotiSearchAutocomplete.sew_formatItem,autoFill:false,onItemSelect:keyotiSearchAutocomplete.sew_item_selected,//##NOCRUNCH
extraParams:{cl:"SBAC",id:keyotiSearchAutocomplete.options.indexDirectory!=null?keyotiSearchAutocomplete.options.indexDirectory:keyotiSearch.indexDirectory,tl:keyotiSearchAutocomplete.options.sew_showNumberOfResults,n:keyotiSearchAutocomplete.options.sew_numberOfSuggestions,p:keyotiSearchAutocomplete.options.sew_autoCompleteQueryLoadPlugin?"1":"0",s:keyotiSearchAutocomplete.options.sew_source,hd:keyotiSearchAutocomplete.options.sew_hideNoResulters},//##ENDNOCRUNCH
sew_searchButtonID:keyotiSearchAutocomplete.options.sew_searchButtonID,sew_runSearchOnSelect:keyotiSearchAutocomplete.options.sew_runSearchOnSelect,sew_searchPostback:keyotiSearchAutocomplete.options.sew_searchPostback});keyotiSearchAutocomplete.sew_queryTB=KSQ("#"+keyotiSearchAutocomplete.options.sew_queryTextBoxID)[0];if(keyotiSearchAutocomplete.sew_queryTB!=null)sew_copyComputedStyle(KSQ.style(".sew_suggestion"),keyotiSearchAutocomplete.sew_queryTB);if(keyotiSearchAutocomplete.sew_queryTB!=null)sew_copyComputedStyle(KSQ.style(".sew_results"),keyotiSearchAutocomplete.sew_queryTB,"nocolor")}};KSQ.autocomplete=function(input,options){// Create a link to self
var me=this;// Create KSQ object for input element
var $input=KSQ(input).attr("autocomplete","off");// Apply inputClass if necessary
if(options.inputClass)$input.addClass(options.inputClass);// Create results
var results=document.createElement("div");// Create KSQ object for results
var $results=KSQ(results);$results.hide().addClass(options.resultsClass).css("position","absolute");if(options.width>0)$results.css("width",options.width);// Add to body element
KSQ("body").append(results);input.autocompleter=me;var timeout=null;var prev="";var active=-1;var cache={};var keyb=false;var hasFocus=false;var lastKeyPressCode=null;// flush cache
function flushCache(){cache={};cache.data={};cache.length=0}// flush cache
flushCache();// if there is a data array supplied
if(options.data!=null){var sFirstChar="",stMatchSets={},row=[];// no url was specified, we need to adjust the cache length to make sure it fits the local data store
if(typeof options.url!="string")options.cacheLength=1;// loop through the array and create a lookup structure
for(var i=0;i<options.data.length;i++){// if row is a string, make an array otherwise just reference the array
row=typeof options.data[i]=="string"?[options.data[i]]:options.data[i];// if the length is zero, don't add to list
if(row[0].length>0){// get the first character
sFirstChar=row[0].substring(0,1).toLowerCase();// if no lookup array for this character exists, look it up now
if(!stMatchSets[sFirstChar])stMatchSets[sFirstChar]=[];// if the match is a string
stMatchSets[sFirstChar].push(row)}}// add the data items to the cache
for(var k in stMatchSets){// increase the cache size
options.cacheLength++;// add to the cache
addToCache(k,stMatchSets[k])}}$input.keydown(function(e){// track last key pressed
lastKeyPressCode=e.keyCode;switch(e.keyCode){case 38:// up
e.preventDefault();moveSelect(-1);break;case 40:// down
e.preventDefault();moveSelect(1);break;case 9:// tab
case 13:// return
//dont need this, is done automatically if (selectCurrent()) {
// make sure to blur off the current field
$input.get(0).blur();e.preventDefault();//}
break;default:active=-1;if(timeout)clearTimeout(timeout);timeout=setTimeout(function(){onChange()},options.delay);break}}).focus(function(){// track whether the field has focus, we shouldn't process any results if the field no longer has focus
hasFocus=true}).blur(function(){// track whether the field has focus
hasFocus=false;hideResults()});hideResultsNow();function onChange(){// ignore if the following keys are pressed: [del] [shift] [capslock]
if(lastKeyPressCode==46||lastKeyPressCode>8&&lastKeyPressCode<32)return $results.hide();var v=$input.val();if(v==prev)return;prev=v;if(v.length>=options.minChars){$input.addClass(options.loadingClass);requestData(v)}else{$input.removeClass(options.loadingClass);$results.hide()}}function moveSelect(step){var lis=KSQ("li",results);if(!lis)return;active+=step;if(active<0){active=0}else if(active>=lis.size()){active=lis.size()-1}lis.removeClass("sew_ac_over");if(lis[active])KSQ(lis[active]).addClass("sew_ac_over");//jim fill when cursor selecting
$input.val(KSQ(lis[active])[0].selectValue)}function selectCurrent(){var li=KSQ("li.sew_ac_over",results)[0];if(!li){var $li=KSQ("li",results);if(options.selectOnly){if($li.length==1)li=$li[0]}else if(options.selectFirst){li=$li[0]}}if(li){selectItem(li);return true}else{return false}}function selectItem(li){if(!li){li=document.createElement("li");li.extra=[];li.selectValue=""}var v=KSQ.trim(li.selectValue?li.selectValue:li.innerHTML);input.lastSelected=v;prev=v;$results.html("");$input.val(v);hideResultsNow();if(options.onItemSelect)setTimeout(function(){options.onItemSelect(li,options)},1)}// selects a portion of the input string
function createSelection(start,end){// get a reference to the input element
var field=$input.get(0);if(field.createTextRange){var selRange=field.createTextRange();selRange.collapse(true);selRange.moveStart("character",start);selRange.moveEnd("character",end);selRange.select()}else if(field.setSelectionRange){field.setSelectionRange(start,end)}else{if(field.selectionStart){field.selectionStart=start;field.selectionEnd=end}}field.focus()}// fills in the input box w/the first match (assumed to be the best match)
function autoFill(sValue){// if the last user key pressed was backspace, don't autofill
if(lastKeyPressCode!=8){// fill in the value (keep the case the user has typed)
$input.val($input.val()+sValue.substring(prev.length));// select the portion of the value not typed by the user (so the next character will erase)
createSelection(prev.length,sValue.length)}}function showResults(){// get the position of the input field right now (in case the DOM is shifted)
var pos=findPos(input);// either use the specified width, or autocalculate based on form element
var iWidth=options.width>0?options.width:$input.width();// reposition
$results.css({width:parseInt(iWidth)+"px",top:pos.y+input.offsetHeight+keyotiSearchAutocomplete.sew_menuShiftY+"px",left:pos.x+keyotiSearchAutocomplete.sew_menuShiftX+"px"}).show()}function hideResults(){if(timeout)clearTimeout(timeout);timeout=setTimeout(hideResultsNow,200)}function hideResultsNow(){if(typeof keyotiSearchAutocomplete.sew_autocomplete_nohide!="undefined")return;if(timeout)clearTimeout(timeout);$input.removeClass(options.loadingClass);if($results.is(":visible")){$results.hide()}if(options.mustMatch){var v=$input.val();if(v!=input.lastSelected){selectItem(null)}}}function receiveData(q,data){if(data){if(keyotiSearchAutocomplete.filterFilenames){for(var i=0;i<data.length;i++){var p;if((p=data[i][0].indexOf("."))>-1&&p<data[i][0].length-4){var ext=data[i][0].substring(p,p+4);if(ext==".htm"||ext==".pdf"||ext==".asp"||ext==".doc"||ext==".jsp"||ext==".xls")data.splice(i--,1)}}}keyotiSearchAutocomplete.dataReceived(data,q);$input.removeClass(options.loadingClass);results.innerHTML="";
// if the field no longer has focus or if there are no matches, do not display the drop down
if(!hasFocus||data.length==0)return hideResultsNow();if(KSQ.browser.msie){// we put a styled iframe behind the calendar so HTML SELECT elements don't show through
$results.append(document.createElement("iframe"))}results.appendChild(dataToDom(data));// autofill in the complete box w/the first match as long as the user hasn't entered in more data
if(options.autoFill&&$input.val().toLowerCase()==q.toLowerCase())autoFill(data[0][0]);showResults()}else{hideResultsNow()}}function parseData(data){if(!data)return null;var parsed=[];var rows=data.split(options.lineSeparator);for(var i=0;i<rows.length;i++){var row=KSQ.trim(rows[i]);if(row.indexOf("~Exception/")>-1){var message=row.substring("~Exception/".length);onError("An exception occurred on the server: "+message)}else{if(row){/*
                    parsed[parsed.length] = row.split(options.cellSeparator);
                    parsed[parsed.length-1][0] = parsed[parsed.length-1][0].replace(/\\\|/g,"|");
                    */
parsed[parsed.length]=lastSplit(row,options.cellSeparator)}}}return parsed}function lastSplit(row,separator){//splits once, at the last instance of separator
var p=row.lastIndexOf(separator);if(p==-1)return[row];else return[row.substring(0,p),row.substring(p+1)]}function dataToDom(data){var ul=document.createElement("ul");var num=data.length;// limited results to a max number
if(options.maxItemsToShow>0&&options.maxItemsToShow<num)num=options.maxItemsToShow;for(var i=0;i<num;i++){var row=data[i];if(!row)continue;var li=document.createElement("li");if(options.formatItem){li.innerHTML=options.formatItem(row,i,num,li);li.selectValue=row[0]}else{li.innerHTML=row[0];li.selectValue=row[0]}var extra=null;if(row.length>1){extra=[];for(var j=1;j<row.length;j++){extra[extra.length]=row[j]}}li.extra=extra;ul.appendChild(li);KSQ(li).hover(function(){KSQ("li",ul).removeClass("sew_ac_over");KSQ(this).addClass("sew_ac_over");active=KSQ("li",ul).indexOf(KSQ(this).get(0))},function(){KSQ(this).removeClass("sew_ac_over")}).click(function(e){e.preventDefault();e.stopPropagation();selectItem(this)})}return ul}var requestTimeout=null;function requestData(q){if(!options.matchCase)q=q.toLowerCase();//JIM, no caching		var data = options.cacheLength ? loadFromCache(q) : null;
var data=null;// receive the cached data
if(data){receiveData(q,data)}else{// if ((typeof options.url == "string") && (options.url.length > 0)) {
if(requestTimeout!=null)clearTimeout(requestTimeout);requestTimeout=setTimeout(onTimeout,1e4);options.extraParams.q=q;keyotiSearch.serviceProxy.invoke("GetAutoComplete",options.extraParams,function(data){clearTimeout(requestTimeout);if(data.Exception!=null)keyotiResultViewer.onError({Message:data.Exception,StackTrace:""});else{//  data = parseData(data);
var list=data.Items;var dataArray=[];for(var i=0;i<list.length;i++){dataArray[dataArray.length]=[list[i].Query,list[i].NumberOfResults]}if(typeof keyotiSearchAutocomplete.sew_OnAutoCompleteSuggestionsGenerated=="function")keyotiSearchAutocomplete.sew_OnAutoCompleteSuggestionsGenerated(q,dataArray);addToCache(q,dataArray);receiveData(q,dataArray)}},function(error){//AJAX error
keyotiResultViewer.showServerError(error);keyotiResultViewer.getResultControlPanel().removeClass("loading")})}}function onTimeout(){onError("Sorry the server didn't respond to the AutoComplete request, please ensure you have added "+'<add verb="*" path="Keyoti.SearchEngine.Web.CallBackHandler.ashx" type="Keyoti.SearchEngine.Web.CallBackHandler,Keyoti.SearchEngine.Web, Version=2015.6.16.825, Culture=neutral, PublicKeyToken=58d9fd2e9ec4dc0e"/> to your web.config - replacing ? with current version numbers, please see the user guide for more info.')}function onError(message){if(!keyotiSearchAutocomplete.sew_failSilent)alert(message)}function makeUrl(q){var url=options.url+"?q="+encodeURI(q);for(var i in options.extraParams){url+="&"+i+"="+encodeURI(options.extraParams[i])}return url+"&nocache="+Math.floor(Math.random()*99999)}function loadFromCache(q){if(!q)return null;if(cache.data[q])return cache.data[q];if(options.matchSubset){for(var i=q.length-1;i>=options.minChars;i--){var qs=q.substr(0,i);
var c=cache.data[qs];if(c){var csub=[];for(var j=0;j<c.length;j++){var x=c[j];var x0=x[0];if(matchSubset(x0,q)){csub[csub.length]=x}}return csub}}}return null}function matchSubset(s,sub){if(!options.matchCase)s=s.toLowerCase();var i=s.indexOf(sub);if(i==-1)return false;return i==0||options.matchContains}this.flushCache=function(){flushCache()};this.setExtraParams=function(p){options.extraParams=p};this.findValue=function(){var q=$input.val();if(!options.matchCase)q=q.toLowerCase();var data=options.cacheLength?loadFromCache(q):null;if(data){findValueCallback(q,data)}else if(typeof options.url=="string"&&options.url.length>0){KSQ.get(makeUrl(q),function(data){data=parseData(data);addToCache(q,data);findValueCallback(q,data)})}else{// no matches
findValueCallback(q,null)}};function findValueCallback(q,data){if(data)$input.removeClass(options.loadingClass);var num=data?data.length:0;var li=null;for(var i=0;i<num;i++){var row=data[i];if(row[0].toLowerCase()==q.toLowerCase()){li=document.createElement("li");if(options.formatItem){li.innerHTML=options.formatItem(row,i,num,li);li.selectValue=row[0]}else{li.innerHTML=row[0];li.selectValue=row[0]}var extra=null;if(row.length>1){extra=[];for(var j=1;j<row.length;j++){extra[extra.length]=row[j]}}li.extra=extra}}if(options.onFindValue)setTimeout(function(){options.onFindValue(li)},1)}function addToCache(q,data){if(!data||!q||!options.cacheLength)return;if(!cache.length||cache.length>options.cacheLength){flushCache();cache.length++}else if(!cache[q]){cache.length++}cache.data[q]=data}function findPos(obj){var curleft=obj.offsetLeft||0;var curtop=obj.offsetTop||0;while(obj=obj.offsetParent){curleft+=obj.offsetLeft;curtop+=obj.offsetTop}return{x:curleft,y:curtop}}};KSQ.fn.autocomplete=function(url,options,data){// Make sure options exists
options=options||{};// Set url as option
options.url=url;// set some bulk local data
options.data=typeof data=="object"&&data.constructor==Array?data:null;// Set default values for required options
options.inputClass=options.inputClass||"ac_input";options.resultsClass=options.resultsClass||"sew_ac_results";options.lineSeparator=options.lineSeparator||"\n";options.cellSeparator=options.cellSeparator||"|";options.minChars=options.minChars||1;options.delay=options.delay||400;options.matchCase=options.matchCase||0;options.matchSubset=options.matchSubset||1;options.matchContains=options.matchContains||0;options.cacheLength=options.cacheLength||1;options.mustMatch=options.mustMatch||0;options.extraParams=options.extraParams||{};options.loadingClass=options.loadingClass||"sew_ac_loading";options.selectFirst=options.selectFirst||false;options.selectOnly=options.selectOnly||false;options.maxItemsToShow=options.maxItemsToShow||-1;options.autoFill=options.autoFill||false;options.width=parseInt(options.width,10)||0;this.each(function(){var input=this;new KSQ.autocomplete(input,options)});// Don't break the chain
return this};KSQ.fn.autocompleteArray=function(data,options){return this.autocomplete(null,options,data)};KSQ.fn.indexOf=function(e){for(var i=0;i<this.length;i++){if(this[i]==e)return i}return-1};//--------------------------------------
KSQ.style=function(selector,options){options=KSQ.extend({type:"text/css",media:"all"},options);var sheet=KSQ.style.sheets[options.media];if(!sheet){var style=KSQ(document.createElement("style")).attr(options).appendTo("head")[0];if(style.styleSheet){// IE
KSQ.style.sheets[options.media]=sheet=style.styleSheet}else if(style.sheet){// Firefox
KSQ.style.sheets[options.media]=sheet=style.sheet;sheet.rules=[]}}if(sheet.rules){if(sheet.rules[selector])return KSQ(sheet.rules[selector]);if(sheet.cssRules){// Firefox
sheet.insertRule(selector+" {}",sheet.cssRules.length);return KSQ(sheet.rules[selector]=sheet.cssRules[sheet.cssRules.length-1])}else{// IE
sheet.addRule(selector,null);return KSQ(sheet.rules[selector]=sheet.rules[sheet.rules.length-1])}}};KSQ.style.sheets=[];//copies style from sEl to tEl
function sew_copyComputedStyle(tEl,sEl,opt){var col;if(sEl.currentStyle)col=sEl.currentStyle;else if(document.defaultView&&document.defaultView.getComputedStyle)col=document.defaultView.getComputedStyle(sEl,null);else{return}for(sp in col)try{if(sp.indexOf("font")>-1||sp.indexOf("text")>-1||sp=="color"&&opt!="nocolor"){var v=sew_getStyleProperty(sEl,sp);if(sp=="color"&&keyotiSearchAutocomplete.sew_OC[sEl.id]!=null)v=keyotiSearchAutocomplete.sew_OC[sEl.id];if(typeof v!="undefined"&&v!="")tEl.css(sp,v)}}catch(ex){}}function sew_getStyleProperty(obj,IEStyleProp){if(obj.currentStyle){//IE 
return obj.currentStyle[IEStyleProp]}else if(document.defaultView.getComputedStyle){//W3C 
return document.defaultView.getComputedStyle(obj,null)[IEStyleProp]}else{return null}}KSQ(document).ready(keyotiSearch._onDocumentReady);/**
Singleton manage the result preview widget
@namespace
*/
var keyotiSearchResultPreviewer={/**
	The DIV element that will hold previews
	@type {Object}
	*/
currentPreviewDIV:null,/**
	The index directory to work with
	@type {String}
	*/
indexDirectory:null,/*'appPath': "",*/
/**
	Whether to load the plugin for the previewer request, this allows the plugin to modify the text to be previewed
	@type {Boolean}
	*/
previewLoadPlugin:false,/**
	Maximum number of characters to retrieve for the previewed document text
	@type {Number}
	*/
maxCharLength:25e3,/**
	HTML to use to format hits within the preview pane, default is &lt;span class='sew_previewHighlight'&gt;{0}&lt;/span&gt;
	@type {String}
	*/
keyword_highlightPattern:"<span class='sew_previewHighlight'>{0}</span>",/**

    */
toggleResultPreview:function(button,url,closedImgURL,openedImgURL){this.currentPreviewDIV=KSQ(button).next();if(button.sew_opened==true){keyotiResultViewer.expandResultControlPanel(0);//keyotiResultViewer.shrinkResultControlPanel(150);
this.currentPreviewDIV.hide("fast");button.src=closedImgURL;button.sew_opened=false}else{button.src=openedImgURL;button.sew_opened=true;//currentPreviewDIV.show("slow");
keyotiResultViewer.expandResultControlPanel(150);//currentPreviewDIV.slideToggle(1000);
this.currentPreviewDIV.show("slow");keyotiSearch.serviceProxy.invoke("GetPreviewText",{indexDirectory:this.indexDirectory!=null?this.indexDirectory:keyotiSearch.indexDirectory,u:url,p:this.previewLoadPlugin?1:0,mx:this.maxCharLength},function(data){if(keyotiSearchResultPreviewer.currentPreviewDIV!=null){if(typeof keyotiSearchResultPreviewer.sew_OnResultPreviewTextLoaded=="function"){dataOut=keyotiSearchResultPreviewer.sew_OnResultPreviewTextLoaded(url,data.Value,button,closedImgURL,openedImgURL);if(dataOut!=null)data.Value=dataOut}if(data.Exception!=null)keyotiResultViewer.onError({Message:data.Exception,StackTrace:""});else{var text=data.Value.replace(/</g,"&lt;");text=text.replace(/>/g,"&gt;");text=text.replace(/\n/g,"<br /><br />");//highlight
/*for (var k = 0; k < keyotiSearch.queryKeywords.length; k++) {
                            text = text.replace(new RegExp("\\b(" + keyotiSearch.queryKeywords[k] + ")\\b", "gi"), keyotiSearchResultPreviewer.keyword_highlightPattern.replace("{0}", "$1"));
                        }*/
text=keyotiSearch.highlightText(text,keyotiSearchResultPreviewer.keyword_highlightPattern);keyotiSearchResultPreviewer.currentPreviewDIV.html(text);keyotiSearchResultPreviewer.currentPreviewDIV=null}}},keyotiResultViewer.onError)}}};//Copyright (c) 2013 Crystalline Technologies
//
//  Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the 'Software'),
//  to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
//  and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
//  The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
//  THE SOFTWARE IS PROVIDED 'AS IS', WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
//  WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
var kjson2html={/* ---------------------------------------- Public Methods ------------------------------------------------ */
transform:function(json,transform,_options){//create the default output
var out={events:[],html:""};//default options (by default we don't allow events)
var options={events:false};//extend the options
options=kjson2html._extend(options,_options);//Make sure we have a transform & json object
if(transform!==undefined||json!==undefined){//Normalize strings to JSON objects if necessary
var obj=typeof json==="string"?JSON.parse(json):json;//Transform the object (using the options)
out=kjson2html._transform(obj,transform,options)}//determine if we need the events
// otherwise return just the html string
if(options.events)return out;else return out.html},/* ---------------------------------------- Private Methods ------------------------------------------------ */
//Extend options
_extend:function(obj1,obj2){var obj3={};for(var attrname in obj1){obj3[attrname]=obj1[attrname]}for(var attrname in obj2){obj3[attrname]=obj2[attrname]}return obj3},//Append results
_append:function(obj1,obj2){var out={html:"",event:[]};if(typeof obj1!=="undefined"&&typeof obj2!=="undefined"){out.html=obj1.html+obj2.html;out.events=obj1.events.concat(obj2.events)}return out},//isArray (fix for IE prior to 9)
_isArray:function(obj){return Object.prototype.toString.call(obj)==="[object Array]"},//Transform object
_transform:function(json,transform,options){var elements={events:[],html:""};//Determine the type of this object
if(kjson2html._isArray(json)){//Itterrate through the array and add it to the elements array
var len=json.length;for(var j=0;j<len;++j){//Apply the transform to this object and append it to the results
elements=kjson2html._append(elements,kjson2html._apply(json[j],transform,j,options))}}else if(typeof json==="object"){//Apply the transform to this object and append it to the results
elements=kjson2html._append(elements,kjson2html._apply(json,transform,undefined,options))}//Return the resulting elements
return elements},//Apply the transform at the second level
_apply:function(obj,transform,index,options){var element={events:[],html:""};//Itterate through the transform and create html as needed
if(kjson2html._isArray(transform)){var t_len=transform.length;for(var t=0;t<t_len;++t){//transform the object and append it to the output
element=kjson2html._append(element,kjson2html._apply(obj,transform[t],index,options))}}else if(typeof transform==="object"){//Get the tag element of this transform
if(transform.tag!==undefined){//Create a new element
element.html+="<"+transform.tag;//Create a new object for the children
var children={events:[],html:""};//innerHTML
var html;//Look into the properties of this transform
for(var key in transform){switch(key){case"tag"://Do nothing as we have already created the element from the tag
break;case"children"://Add the children
if(kjson2html._isArray(transform.children)){//Apply the transform to the children
children=kjson2html._append(children,kjson2html._apply(obj,transform.children,index,options))}else if(typeof transform.children==="function"){//Get the result from the function
var temp=transform.children.call(obj,obj,index);//Make sure we have an object result with the props
// html (string), events (array)
// OR a string (then just append it to the children
if(typeof temp==="object"){//make sure this object is a valid kjson2html response object
if(temp.html!==undefined&&temp.events!==undefined)children=kjson2html._append(children,temp)}else if(typeof temp==="string"){//append the result directly to the html of the children
children.html+=temp}}break;case"html"://Create the html attribute for this element
html=kjson2html._getValue(obj,transform,"html",index);break;default://Add the property as a attribute if it's not a key one
var isEvent=false;//Check if the first two characters are 'on' then this is an event
if(key.length>2)if(key.substring(0,2).toLowerCase()=="on"){//Determine if we should add events
if(options.events){//if so then setup the event data
var data={action:transform[key],obj:obj,data:options.eventData,index:index};//create a new id for this event
var id=kjson2html._guid();//append the new event to this elements events
element.events[element.events.length]={id:id,type:key.substring(2),data:data};//Insert temporary event property (kjson2html-event-id) into the element
element.html+=" kjson2html-event-id-"+key.substring(2)+"='"+id+"'"}//this is an event
isEvent=true}//If this wasn't an event AND we actually have a value then add it as a property
if(!isEvent){//Get the value
var val=kjson2html._getValue(obj,transform,key,index);//Make sure we have a value
if(val!==undefined){var out;//Determine the output type of this value (wrap with quotes)
if(typeof val==="string")out='"'+val.replace(/"/g,"&quot;")+'"';else out=val;//creat the name value pair
element.html+=" "+key+"="+out}}break}}//close the opening tag
element.html+=">";//add the innerHTML (if we have any)
if(html)element.html+=html;//add the children (if we have any)
element=kjson2html._append(element,children);//add the closing tag
element.html+="</"+transform.tag+">"}}//Return the output object
return element},//Get a new GUID (used by events)
_guid:function(){var S4=function(){return((1+Math.random())*65536|0).toString(16).substring(1)};return S4()+S4()+"-"+S4()+S4()+"-"+S4()+S4()},//Get the html value of the object
_getValue:function(obj,transform,key,index){var out="";var val=transform[key];var type=typeof val;if(type==="function"){return val.call(obj,obj,index)}else if(type==="string"){var _tokenizer=new kjson2html._tokenizer([/\$\{([^\}\{]+)\}/],function(src,real,re){return real?src.replace(re,function(all,name){//Split the string into it's seperate components
var components=name.split(".");//Set the object we use to query for this name to be the original object
var useObj=obj;//Output value
var outVal="";//Parse the object components
var c_len=components.length;for(var i=0;i<c_len;++i){if(components[i].length>0){var newObj=useObj[components[i]];useObj=newObj;if(useObj===null||useObj===undefined)break}}//As long as we have an object to use then set the out
if(useObj!==null&&useObj!==undefined)outVal=useObj;return outVal}):src});out=_tokenizer.parse(val).join("")}else{out=val}return out},//Tokenizer
_tokenizer:function(tokenizers,doBuild){if(!(this instanceof kjson2html._tokenizer))return new kjson2html._tokenizer(tokenizers,doBuild);this.tokenizers=tokenizers.splice?tokenizers:[tokenizers];if(doBuild)this.doBuild=doBuild;this.parse=function(src){this.src=src;this.ended=false;this.tokens=[];do{this.next()}while(!this.ended);return this.tokens};this.build=function(src,real){if(src)this.tokens.push(!this.doBuild?src:this.doBuild(src,real,this.tkn))};this.next=function(){var self=this,plain;self.findMin();plain=self.src.slice(0,self.min);self.build(plain,false);self.src=self.src.slice(self.min).replace(self.tkn,function(all){self.build(all,true);return""});if(!self.src)self.ended=true};this.findMin=function(){var self=this,i=0,tkn,idx;self.min=-1;self.tkn="";while((tkn=self.tokenizers[i++])!==undefined){idx=self.src[tkn.test?"search":"indexOf"](tkn);if(idx!=-1&&(self.min==-1||idx<self.min)){self.tkn=tkn;self.min=idx}}if(self.min==-1)self.min=self.src.length}}};(function($){//Main method
$.fn.kjson2html=function(json,transform,_options){//Make sure we have the kjson2html base loaded
if(typeof kjson2html==="undefined")return undefined;//Default Options
var options={append:true,replace:false,prepend:false,eventData:{}};//Extend the options (with defaults)
if(_options!==undefined)$.extend(options,_options);//Insure that we have the events turned (Required)
options.events=true;//Make sure to take care of any chaining
return this.each(function(){//let kjson2html core do it's magic
var result=kjson2html.transform(json,transform,options);//Attach the html(string) result to the DOM
var dom=$(document.createElement("i")).html(result.html);//Determine if we have events
for(var i=0;i<result.events.length;i++){var event=result.events[i];//find the associated DOM object with this event
var obj=$(dom).find("[kjson2html-event-id-"+event.type+"='"+event.id+"']");//Check to see if we found this element or not
if(obj.length===0)throw"jquery.kjson2html was unable to attach event "+event.id+" to DOM";//remove the attribute
$(obj).removeAttr("kjson2html-event-id-"+event.type);//attach the event
$(obj).on(event.type,event.data,function(e){//attach the jquery event
e.data.event=e;//call the appropriate method
e.data.action.call($(this),e.data)})}//Append it to the appropriate element
if(options.replace)$.fn.replaceWith.call($(this),$(dom).children());else if(options.prepend)$.fn.prepend.call($(this),$(dom).children());else $.fn.append.call($(this),$(dom).children())})}})(KSQ);(function($){$.fn.getAttributes=function(){var elem=this,attr={};if(elem&&elem.length)$.each(elem.get(0).attributes,function(v,n){n=n.nodeName||n.name;v=elem.attr(n);// relay on $.fn.attr, it makes some filtering and checks
if(v!=undefined&&v!==false)attr[n]=v});return attr}})(KSQ);/*---HISTORY.JS-------------------------------------------------------------------------------------
# License

Copyright &copy; 2014+ Bevry Pty Ltd <us@bevry.me> (http://bevry.me)
<br/>Copyright &copy; 2011-2013 Benjamin Lupton <b@lupton.cc> (http://balupton.com)

## The New BSD License

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

- Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
- Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
- Neither the name of Benjamin Arthur Lupton nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
typeof JSON!="object"&&(JSON={}),function(){"use strict";function f(e){return e<10?"0"+e:e}function quote(e){return escapable.lastIndex=0,escapable.test(e)?'"'+e.replace(escapable,function(e){var t=meta[e];return typeof t=="string"?t:"\\u"+("0000"+e.charCodeAt(0).toString(16)).slice(-4)})+'"':'"'+e+'"'}function str(e,t){var n,r,i,s,o=gap,u,a=t[e];a&&typeof a=="object"&&typeof a.toJSON=="function"&&(a=a.toJSON(e)),typeof rep=="function"&&(a=rep.call(t,e,a));switch(typeof a){case"string":return quote(a);case"number":return isFinite(a)?String(a):"null";case"boolean":case"null":return String(a);case"object":if(!a)return"null";gap+=indent,u=[];if(Object.prototype.toString.apply(a)==="[object Array]"){s=a.length;for(n=0;n<s;n+=1)u[n]=str(n,a)||"null";return i=u.length===0?"[]":gap?"[\n"+gap+u.join(",\n"+gap)+"\n"+o+"]":"["+u.join(",")+"]",gap=o,i}if(rep&&typeof rep=="object"){s=rep.length;for(n=0;n<s;n+=1)typeof rep[n]=="string"&&(r=rep[n],i=str(r,a),i&&u.push(quote(r)+(gap?": ":":")+i))}else for(r in a)Object.prototype.hasOwnProperty.call(a,r)&&(i=str(r,a),i&&u.push(quote(r)+(gap?": ":":")+i));
return i=u.length===0?"{}":gap?"{\n"+gap+u.join(",\n"+gap)+"\n"+o+"}":"{"+u.join(",")+"}",gap=o,i}}typeof Date.prototype.toJSON!="function"&&(Date.prototype.toJSON=function(e){return isFinite(this.valueOf())?this.getUTCFullYear()+"-"+f(this.getUTCMonth()+1)+"-"+f(this.getUTCDate())+"T"+f(this.getUTCHours())+":"+f(this.getUTCMinutes())+":"+f(this.getUTCSeconds())+"Z":null},String.prototype.toJSON=Number.prototype.toJSON=Boolean.prototype.toJSON=function(e){return this.valueOf()});var cx=/[\u0000\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g,escapable=/[\\\"\x00-\x1f\x7f-\x9f\u00ad\u0600-\u0604\u070f\u17b4\u17b5\u200c-\u200f\u2028-\u202f\u2060-\u206f\ufeff\ufff0-\uffff]/g,gap,indent,meta={"\b":"\\b","	":"\\t","\n":"\\n","\f":"\\f","\r":"\\r",'"':'\\"',"\\":"\\\\"},rep;typeof JSON.stringify!="function"&&(JSON.stringify=function(e,t,n){var r;gap="",indent="";if(typeof n=="number")for(r=0;r<n;r+=1)indent+=" ";else typeof n=="string"&&(indent=n);
rep=t;if(!t||typeof t=="function"||typeof t=="object"&&typeof t.length=="number")return str("",{"":e});throw new Error("JSON.stringify")}),typeof JSON.parse!="function"&&(JSON.parse=function(text,reviver){function walk(e,t){var n,r,i=e[t];if(i&&typeof i=="object")for(n in i)Object.prototype.hasOwnProperty.call(i,n)&&(r=walk(i,n),r!==undefined?i[n]=r:delete i[n]);return reviver.call(e,t,i)}var j;text=String(text),cx.lastIndex=0,cx.test(text)&&(text=text.replace(cx,function(e){return"\\u"+("0000"+e.charCodeAt(0).toString(16)).slice(-4)}));if(/^[\],:{}\s]*$/.test(text.replace(/\\(?:["\\\/bfnrt]|u[0-9a-fA-F]{4})/g,"@").replace(/"[^"\\\n\r]*"|true|false|null|-?\d+(?:\.\d*)?(?:[eE][+\-]?\d+)?/g,"]").replace(/(?:^|:|,)(?:\s*\[)+/g,"")))return j=eval("("+text+")"),typeof reviver=="function"?walk({"":j},""):j;throw new SyntaxError("JSON.parse")})}(),function(e,t){"use strict";var n=e.History=e.History||{};if(typeof n.Adapter!="undefined")throw new Error("History.js Adapter has already been loaded...");
n.Adapter={handlers:{},_uid:1,uid:function(e){return e._uid||(e._uid=n.Adapter._uid++)},bind:function(e,t,r){var i=n.Adapter.uid(e);n.Adapter.handlers[i]=n.Adapter.handlers[i]||{},n.Adapter.handlers[i][t]=n.Adapter.handlers[i][t]||[],n.Adapter.handlers[i][t].push(r),e["on"+t]=function(e,t){return function(r){n.Adapter.trigger(e,t,r)}}(e,t)},trigger:function(e,t,r){r=r||{};var i=n.Adapter.uid(e),s,o;n.Adapter.handlers[i]=n.Adapter.handlers[i]||{},n.Adapter.handlers[i][t]=n.Adapter.handlers[i][t]||[];for(s=0,o=n.Adapter.handlers[i][t].length;s<o;++s)n.Adapter.handlers[i][t][s].apply(this,[r])},extractEventData:function(e,n){var r=n&&n[e]||t;return r},onDomLoad:function(t){var n=e.setTimeout(function(){t()},2e3);e.onload=function(){clearTimeout(n),t()}}},typeof n.init!="undefined"&&n.init()}(window),function(e,t){"use strict";var n=e.document,r=e.setTimeout||r,i=e.clearTimeout||i,s=e.setInterval||s,o=e.History=e.History||{};if(typeof o.initHtml4!="undefined")throw new Error("History.js HTML4 Support has already been loaded...");
o.initHtml4=function(){if(typeof o.initHtml4.initialized!="undefined")return!1;o.initHtml4.initialized=!0,o.enabled=!0,o.savedHashes=[],o.isLastHash=function(e){var t=o.getHashByIndex(),n;return n=e===t,n},o.isHashEqual=function(e,t){return e=encodeURIComponent(e).replace(/%25/g,"%"),t=encodeURIComponent(t).replace(/%25/g,"%"),e===t},o.saveHash=function(e){return o.isLastHash(e)?!1:(o.savedHashes.push(e),!0)},o.getHashByIndex=function(e){var t=null;return typeof e=="undefined"?t=o.savedHashes[o.savedHashes.length-1]:e<0?t=o.savedHashes[o.savedHashes.length+e]:t=o.savedHashes[e],t},o.discardedHashes={},o.discardedStates={},o.discardState=function(e,t,n){var r=o.getHashByState(e),i;return i={discardedState:e,backState:n,forwardState:t},o.discardedStates[r]=i,!0},o.discardHash=function(e,t,n){var r={discardedHash:e,backState:n,forwardState:t};return o.discardedHashes[e]=r,!0},o.discardedState=function(e){var t=o.getHashByState(e),n;return n=o.discardedStates[t]||!1,n},o.discardedHash=function(e){var t=o.discardedHashes[e]||!1;
return t},o.recycleState=function(e){var t=o.getHashByState(e);return o.discardedState(e)&&delete o.discardedStates[t],!0},o.emulated.hashChange&&(o.hashChangeInit=function(){o.checkerFunction=null;var t="",r,i,u,a,f=Boolean(o.getHash());return o.isInternetExplorer()?(r="historyjs-iframe",i=n.createElement("iframe"),i.setAttribute("id",r),i.setAttribute("src","#"),i.style.display="none",n.body.appendChild(i),i.contentWindow.document.open(),i.contentWindow.document.close(),u="",a=!1,o.checkerFunction=function(){if(a)return!1;a=!0;var n=o.getHash(),r=o.getHash(i.contentWindow.document);return n!==t?(t=n,r!==n&&(u=r=n,i.contentWindow.document.open(),i.contentWindow.document.close(),i.contentWindow.document.location.hash=o.escapeHash(n)),o.Adapter.trigger(e,"hashchange")):r!==u&&(u=r,f&&r===""?o.back():o.setHash(r,!1)),a=!1,!0}):o.checkerFunction=function(){var n=o.getHash()||"";return n!==t&&(t=n,o.Adapter.trigger(e,"hashchange")),!0},o.intervalList.push(s(o.checkerFunction,o.options.hashChangeInterval)),!0
},o.Adapter.onDomLoad(o.hashChangeInit)),o.emulated.pushState&&(o.onHashChange=function(t){var n=t&&t.newURL||o.getLocationHref(),r=o.getHashByUrl(n),i=null,s=null,u=null,a;return o.isLastHash(r)?(o.busy(!1),!1):(o.doubleCheckComplete(),o.saveHash(r),r&&o.isTraditionalAnchor(r)?(o.Adapter.trigger(e,"anchorchange"),o.busy(!1),!1):(i=o.extractState(o.getFullUrl(r||o.getLocationHref()),!0),o.isLastSavedState(i)?(o.busy(!1),!1):(s=o.getHashByState(i),a=o.discardedState(i),a?(o.getHashByIndex(-2)===o.getHashByState(a.forwardState)?o.back(!1):o.forward(!1),!1):(o.pushState(i.data,i.title,encodeURI(i.url),!1),!0))))},o.Adapter.bind(e,"hashchange",o.onHashChange),o.pushState=function(t,n,r,i){r=encodeURI(r).replace(/%25/g,"%");if(o.getHashByUrl(r))throw new Error("History.js does not support states with fragment-identifiers (hashes/anchors).");if(i!==!1&&o.busy())return o.pushQueue({scope:o,callback:o.pushState,args:arguments,queue:i}),!1;o.busy(!0);var s=o.createStateObject(t,n,r),u=o.getHashByState(s),a=o.getState(!1),f=o.getHashByState(a),l=o.getHash(),c=o.expectedStateId==s.id;
return o.storeState(s),o.expectedStateId=s.id,o.recycleState(s),o.setTitle(s),u===f?(o.busy(!1),!1):(o.saveState(s),c||o.Adapter.trigger(e,"statechange"),!o.isHashEqual(u,l)&&!o.isHashEqual(u,o.getShortUrl(o.getLocationHref()))&&o.setHash(u,!1),o.busy(!1),!0)},o.replaceState=function(t,n,r,i){r=encodeURI(r).replace(/%25/g,"%");if(o.getHashByUrl(r))throw new Error("History.js does not support states with fragment-identifiers (hashes/anchors).");if(i!==!1&&o.busy())return o.pushQueue({scope:o,callback:o.replaceState,args:arguments,queue:i}),!1;o.busy(!0);var s=o.createStateObject(t,n,r),u=o.getHashByState(s),a=o.getState(!1),f=o.getHashByState(a),l=o.getStateByIndex(-2);return o.discardState(a,s,l),u===f?(o.storeState(s),o.expectedStateId=s.id,o.recycleState(s),o.setTitle(s),o.saveState(s),o.Adapter.trigger(e,"statechange"),o.busy(!1)):o.pushState(s.data,s.title,s.url,!1),!0}),o.emulated.pushState&&o.getHash()&&!o.emulated.hashChange&&o.Adapter.onDomLoad(function(){o.Adapter.trigger(e,"hashchange")
})},typeof o.init!="undefined"&&o.init()}(window),function(e,t){"use strict";var n=e.console||t,r=e.document,i=e.navigator,s=!1,o=e.setTimeout,u=e.clearTimeout,a=e.setInterval,f=e.clearInterval,l=e.JSON,c=e.alert,h=e.History=e.History||{},p=e.history;try{s=e.sessionStorage,s.setItem("TEST","1"),s.removeItem("TEST")}catch(d){s=!1}l.stringify=l.stringify||l.encode,l.parse=l.parse||l.decode;if(typeof h.init!="undefined")throw new Error("History.js Core has already been loaded...");h.init=function(e){return typeof h.Adapter=="undefined"?!1:(typeof h.initCore!="undefined"&&h.initCore(),typeof h.initHtml4!="undefined"&&h.initHtml4(),!0)},h.initCore=function(d){if(typeof h.initCore.initialized!="undefined")return!1;h.initCore.initialized=!0,h.options=h.options||{},h.options.hashChangeInterval=h.options.hashChangeInterval||100,h.options.safariPollInterval=h.options.safariPollInterval||500,h.options.doubleCheckInterval=h.options.doubleCheckInterval||500,h.options.disableSuid=h.options.disableSuid||!1,h.options.storeInterval=h.options.storeInterval||1e3,h.options.busyDelay=h.options.busyDelay||250,h.options.debug=h.options.debug||!1,h.options.initialTitle=h.options.initialTitle||r.title,h.options.html4Mode=h.options.html4Mode||!1,h.options.delayInit=h.options.delayInit||!1,h.intervalList=[],h.clearAllIntervals=function(){var e,t=h.intervalList;
if(typeof t!="undefined"&&t!==null){for(e=0;e<t.length;e++)f(t[e]);h.intervalList=null}},h.debug=function(){(h.options.debug||!1)&&h.log.apply(h,arguments)},h.log=function(){var e=typeof n!="undefined"&&typeof n.log!="undefined"&&typeof n.log.apply!="undefined",t=r.getElementById("log"),i,s,o,u,a;e?(u=Array.prototype.slice.call(arguments),i=u.shift(),typeof n.debug!="undefined"?n.debug.apply(n,[i,u]):n.log.apply(n,[i,u])):i="\n"+arguments[0]+"\n";for(s=1,o=arguments.length;s<o;++s){a=arguments[s];if(typeof a=="object"&&typeof l!="undefined")try{a=l.stringify(a)}catch(f){}i+="\n"+a+"\n"}return t?(t.value+=i+"\n-----\n",t.scrollTop=t.scrollHeight-t.clientHeight):e||c(i),!0},h.getInternetExplorerMajorVersion=function(){var e=h.getInternetExplorerMajorVersion.cached=typeof h.getInternetExplorerMajorVersion.cached!="undefined"?h.getInternetExplorerMajorVersion.cached:function(){var e=3,t=r.createElement("div"),n=t.getElementsByTagName("i");while((t.innerHTML="<!--[if gt IE "+ ++e+"]><i></i><![endif]-->")&&n[0]);return e>4?e:!1
}();return e},h.isInternetExplorer=function(){var e=h.isInternetExplorer.cached=typeof h.isInternetExplorer.cached!="undefined"?h.isInternetExplorer.cached:Boolean(h.getInternetExplorerMajorVersion());return e},h.options.html4Mode?h.emulated={pushState:!0,hashChange:!0}:h.emulated={pushState:!Boolean(e.history&&e.history.pushState&&e.history.replaceState&&!/ Mobile\/([1-7][a-z]|(8([abcde]|f(1[0-8]))))/i.test(i.userAgent)&&!/AppleWebKit\/5([0-2]|3[0-2])/i.test(i.userAgent)),hashChange:Boolean(!("onhashchange"in e||"onhashchange"in r)||h.isInternetExplorer()&&h.getInternetExplorerMajorVersion()<8)},h.enabled=!h.emulated.pushState,h.bugs={setHash:Boolean(!h.emulated.pushState&&i.vendor==="Apple Computer, Inc."&&/AppleWebKit\/5([0-2]|3[0-3])/.test(i.userAgent)),safariPoll:Boolean(!h.emulated.pushState&&i.vendor==="Apple Computer, Inc."&&/AppleWebKit\/5([0-2]|3[0-3])/.test(i.userAgent)),ieDoubleCheck:Boolean(h.isInternetExplorer()&&h.getInternetExplorerMajorVersion()<8),hashEscape:Boolean(h.isInternetExplorer()&&h.getInternetExplorerMajorVersion()<7)},h.isEmptyObject=function(e){for(var t in e)if(e.hasOwnProperty(t))return!1;
return!0},h.cloneObject=function(e){var t,n;return e?(t=l.stringify(e),n=l.parse(t)):n={},n},h.getRootUrl=function(){var e=r.location.protocol+"//"+(r.location.hostname||r.location.host);if(r.location.port||!1)e+=":"+r.location.port;return e+="/",e},h.getBaseHref=function(){var e=r.getElementsByTagName("base"),t=null,n="";return e.length===1&&(t=e[0],n=t.href.replace(/[^\/]+$/,"")),n=n.replace(/\/+$/,""),n&&(n+="/"),n},h.getBaseUrl=function(){var e=h.getBaseHref()||h.getBasePageUrl()||h.getRootUrl();return e},h.getPageUrl=function(){var e=h.getState(!1,!1),t=(e||{}).url||h.getLocationHref(),n;return n=t.replace(/\/+$/,"").replace(/[^\/]+$/,function(e,t,n){return/\./.test(e)?e:e+"/"}),n},h.getBasePageUrl=function(){var e=h.getLocationHref().replace(/[#\?].*/,"").replace(/[^\/]+$/,function(e,t,n){return/[^\/]$/.test(e)?"":e}).replace(/\/+$/,"")+"/";return e},h.getFullUrl=function(e,t){var n=e,r=e.substring(0,1);return t=typeof t=="undefined"?!0:t,/[a-z]+\:\/\//.test(e)||(r==="/"?n=h.getRootUrl()+e.replace(/^\/+/,""):r==="#"?n=h.getPageUrl().replace(/#.*/,"")+e:r==="?"?n=h.getPageUrl().replace(/[\?#].*/,"")+e:t?n=h.getBaseUrl()+e.replace(/^(\.\/)+/,""):n=h.getBasePageUrl()+e.replace(/^(\.\/)+/,"")),n.replace(/\#$/,"")
},h.getShortUrl=function(e){var t=e,n=h.getBaseUrl(),r=h.getRootUrl();return h.emulated.pushState&&(t=t.replace(n,"")),t=t.replace(r,"/"),h.isTraditionalAnchor(t)&&(t="./"+t),t=t.replace(/^(\.\/)+/g,"./").replace(/\#$/,""),t},h.getLocationHref=function(e){return e=e||r,e.URL===e.location.href?e.location.href:e.location.href===decodeURIComponent(e.URL)?e.URL:e.location.hash&&decodeURIComponent(e.location.href.replace(/^[^#]+/,""))===e.location.hash?e.location.href:e.URL.indexOf("#")==-1&&e.location.href.indexOf("#")!=-1?e.location.href:e.URL||e.location.href},h.store={},h.idToState=h.idToState||{},h.stateToId=h.stateToId||{},h.urlToId=h.urlToId||{},h.storedStates=h.storedStates||[],h.savedStates=h.savedStates||[],h.normalizeStore=function(){h.store.idToState=h.store.idToState||{},h.store.urlToId=h.store.urlToId||{},h.store.stateToId=h.store.stateToId||{}},h.getState=function(e,t){typeof e=="undefined"&&(e=!0),typeof t=="undefined"&&(t=!0);var n=h.getLastSavedState();return!n&&t&&(n=h.createStateObject()),e&&(n=h.cloneObject(n),n.url=n.cleanUrl||n.url),n
},h.getIdByState=function(e){var t=h.extractId(e.url),n;if(!t){n=h.getStateString(e);if(typeof h.stateToId[n]!="undefined")t=h.stateToId[n];else if(typeof h.store.stateToId[n]!="undefined")t=h.store.stateToId[n];else{for(;;){t=(new Date).getTime()+String(Math.random()).replace(/\D/g,"");if(typeof h.idToState[t]=="undefined"&&typeof h.store.idToState[t]=="undefined")break}h.stateToId[n]=t,h.idToState[t]=e}}return t},h.normalizeState=function(e){var t,n;if(!e||typeof e!="object")e={};if(typeof e.normalized!="undefined")return e;if(!e.data||typeof e.data!="object")e.data={};return t={},t.normalized=!0,t.title=e.title||"",t.url=h.getFullUrl(e.url?e.url:h.getLocationHref()),t.hash=h.getShortUrl(t.url),t.data=h.cloneObject(e.data),t.id=h.getIdByState(t),t.cleanUrl=t.url.replace(/\??\&_suid.*/,""),t.url=t.cleanUrl,n=!h.isEmptyObject(t.data),(t.title||n)&&h.options.disableSuid!==!0&&(t.hash=h.getShortUrl(t.url).replace(/\??\&_suid.*/,""),/\?/.test(t.hash)||(t.hash+="?"),t.hash+="&_suid="+t.id),t.hashedUrl=h.getFullUrl(t.hash),(h.emulated.pushState||h.bugs.safariPoll)&&h.hasUrlDuplicate(t)&&(t.url=t.hashedUrl),t
},h.createStateObject=function(e,t,n){var r={data:e,title:t,url:n};return r=h.normalizeState(r),r},h.getStateById=function(e){e=String(e);var n=h.idToState[e]||h.store.idToState[e]||t;return n},h.getStateString=function(e){var t,n,r;return t=h.normalizeState(e),n={data:t.data,title:e.title,url:e.url},r=l.stringify(n),r},h.getStateId=function(e){var t,n;return t=h.normalizeState(e),n=t.id,n},h.getHashByState=function(e){var t,n;return t=h.normalizeState(e),n=t.hash,n},h.extractId=function(e){var t,n,r,i;return e.indexOf("#")!=-1?i=e.split("#")[0]:i=e,n=/(.*)\&_suid=([0-9]+)$/.exec(i),r=n?n[1]||e:e,t=n?String(n[2]||""):"",t||!1},h.isTraditionalAnchor=function(e){var t=!/[\/\?\.]/.test(e);return t},h.extractState=function(e,t){var n=null,r,i;return t=t||!1,r=h.extractId(e),r&&(n=h.getStateById(r)),n||(i=h.getFullUrl(e),r=h.getIdByUrl(i)||!1,r&&(n=h.getStateById(r)),!n&&t&&!h.isTraditionalAnchor(e)&&(n=h.createStateObject(null,null,i))),n},h.getIdByUrl=function(e){var n=h.urlToId[e]||h.store.urlToId[e]||t;
return n},h.getLastSavedState=function(){return h.savedStates[h.savedStates.length-1]||t},h.getLastStoredState=function(){return h.storedStates[h.storedStates.length-1]||t},h.hasUrlDuplicate=function(e){var t=!1,n;return n=h.extractState(e.url),t=n&&n.id!==e.id,t},h.storeState=function(e){return h.urlToId[e.url]=e.id,h.storedStates.push(h.cloneObject(e)),e},h.isLastSavedState=function(e){var t=!1,n,r,i;return h.savedStates.length&&(n=e.id,r=h.getLastSavedState(),i=r.id,t=n===i),t},h.saveState=function(e){return h.isLastSavedState(e)?!1:(h.savedStates.push(h.cloneObject(e)),!0)},h.getStateByIndex=function(e){var t=null;return typeof e=="undefined"?t=h.savedStates[h.savedStates.length-1]:e<0?t=h.savedStates[h.savedStates.length+e]:t=h.savedStates[e],t},h.getCurrentIndex=function(){var e=null;return h.savedStates.length<1?e=0:e=h.savedStates.length-1,e},h.getHash=function(e){var t=h.getLocationHref(e),n;return n=h.getHashByUrl(t),n},h.unescapeHash=function(e){var t=h.normalizeHash(e);return t=decodeURIComponent(t),t
},h.normalizeHash=function(e){var t=e.replace(/[^#]*#/,"").replace(/#.*/,"");return t},h.setHash=function(e,t){var n,i;return t!==!1&&h.busy()?(h.pushQueue({scope:h,callback:h.setHash,args:arguments,queue:t}),!1):(h.busy(!0),n=h.extractState(e,!0),n&&!h.emulated.pushState?h.pushState(n.data,n.title,n.url,!1):h.getHash()!==e&&(h.bugs.setHash?(i=h.getPageUrl(),h.pushState(null,null,i+"#"+e,!1)):r.location.hash=e),h)},h.escapeHash=function(t){var n=h.normalizeHash(t);return n=e.encodeURIComponent(n),h.bugs.hashEscape||(n=n.replace(/\%21/g,"!").replace(/\%26/g,"&").replace(/\%3D/g,"=").replace(/\%3F/g,"?")),n},h.getHashByUrl=function(e){var t=String(e).replace(/([^#]*)#?([^#]*)#?(.*)/,"$2");return t=h.unescapeHash(t),t},h.setTitle=function(e){var t=e.title,n;t||(n=h.getStateByIndex(0),n&&n.url===e.url&&(t=n.title||h.options.initialTitle));try{r.getElementsByTagName("title")[0].innerHTML=t.replace("<","&lt;").replace(">","&gt;").replace(" & "," &amp; ")}catch(i){}return r.title=t,h},h.queues=[],h.busy=function(e){typeof e!="undefined"?h.busy.flag=e:typeof h.busy.flag=="undefined"&&(h.busy.flag=!1);
if(!h.busy.flag){u(h.busy.timeout);var t=function(){var e,n,r;if(h.busy.flag)return;for(e=h.queues.length-1;e>=0;--e){n=h.queues[e];if(n.length===0)continue;r=n.shift(),h.fireQueueItem(r),h.busy.timeout=o(t,h.options.busyDelay)}};h.busy.timeout=o(t,h.options.busyDelay)}return h.busy.flag},h.busy.flag=!1,h.fireQueueItem=function(e){return e.callback.apply(e.scope||h,e.args||[])},h.pushQueue=function(e){return h.queues[e.queue||0]=h.queues[e.queue||0]||[],h.queues[e.queue||0].push(e),h},h.queue=function(e,t){return typeof e=="function"&&(e={callback:e}),typeof t!="undefined"&&(e.queue=t),h.busy()?h.pushQueue(e):h.fireQueueItem(e),h},h.clearQueue=function(){return h.busy.flag=!1,h.queues=[],h},h.stateChanged=!1,h.doubleChecker=!1,h.doubleCheckComplete=function(){return h.stateChanged=!0,h.doubleCheckClear(),h},h.doubleCheckClear=function(){return h.doubleChecker&&(u(h.doubleChecker),h.doubleChecker=!1),h},h.doubleCheck=function(e){return h.stateChanged=!1,h.doubleCheckClear(),h.bugs.ieDoubleCheck&&(h.doubleChecker=o(function(){return h.doubleCheckClear(),h.stateChanged||e(),!0
},h.options.doubleCheckInterval)),h},h.safariStatePoll=function(){var t=h.extractState(h.getLocationHref()),n;if(!h.isLastSavedState(t))return n=t,n||(n=h.createStateObject()),h.Adapter.trigger(e,"popstate"),h;return},h.back=function(e){return e!==!1&&h.busy()?(h.pushQueue({scope:h,callback:h.back,args:arguments,queue:e}),!1):(h.busy(!0),h.doubleCheck(function(){h.back(!1)}),p.go(-1),!0)},h.forward=function(e){return e!==!1&&h.busy()?(h.pushQueue({scope:h,callback:h.forward,args:arguments,queue:e}),!1):(h.busy(!0),h.doubleCheck(function(){h.forward(!1)}),p.go(1),!0)},h.go=function(e,t){var n;if(e>0)for(n=1;n<=e;++n)h.forward(t);else{if(!(e<0))throw new Error("History.go: History.go requires a positive or negative integer passed.");for(n=-1;n>=e;--n)h.back(t)}return h};if(h.emulated.pushState){var v=function(){};h.pushState=h.pushState||v,h.replaceState=h.replaceState||v}else h.onPopState=function(t,n){var r=!1,i=!1,s,o;return h.doubleCheckComplete(),s=h.getHash(),s?(o=h.extractState(s||h.getLocationHref(),!0),o?h.replaceState(o.data,o.title,o.url,!1):(h.Adapter.trigger(e,"anchorchange"),h.busy(!1)),h.expectedStateId=!1,!1):(r=h.Adapter.extractEventData("state",t,n)||!1,r?i=h.getStateById(r):h.expectedStateId?i=h.getStateById(h.expectedStateId):i=h.extractState(h.getLocationHref()),i||(i=h.createStateObject(null,null,h.getLocationHref())),h.expectedStateId=!1,h.isLastSavedState(i)?(h.busy(!1),!1):(h.storeState(i),h.saveState(i),h.setTitle(i),h.Adapter.trigger(e,"statechange"),h.busy(!1),!0))
},h.Adapter.bind(e,"popstate",h.onPopState),h.pushState=function(t,n,r,i){if(h.getHashByUrl(r)&&h.emulated.pushState)throw new Error("History.js does not support states with fragement-identifiers (hashes/anchors).");if(i!==!1&&h.busy())return h.pushQueue({scope:h,callback:h.pushState,args:arguments,queue:i}),!1;h.busy(!0);var s=h.createStateObject(t,n,r);return h.isLastSavedState(s)?h.busy(!1):(h.storeState(s),h.expectedStateId=s.id,p.pushState(s.id,s.title,s.url),h.Adapter.trigger(e,"popstate")),!0},h.replaceState=function(t,n,r,i){if(h.getHashByUrl(r)&&h.emulated.pushState)throw new Error("History.js does not support states with fragement-identifiers (hashes/anchors).");if(i!==!1&&h.busy())return h.pushQueue({scope:h,callback:h.replaceState,args:arguments,queue:i}),!1;h.busy(!0);var s=h.createStateObject(t,n,r);return h.isLastSavedState(s)?h.busy(!1):(h.storeState(s),h.expectedStateId=s.id,p.replaceState(s.id,s.title,s.url),h.Adapter.trigger(e,"popstate")),!0};if(s){try{h.store=l.parse(s.getItem("History.store"))||{}
}catch(m){h.store={}}h.normalizeStore()}else h.store={},h.normalizeStore();h.Adapter.bind(e,"unload",h.clearAllIntervals),h.saveState(h.storeState(h.extractState(h.getLocationHref(),!0))),s&&(h.onUnload=function(){var e,t,n;try{e=l.parse(s.getItem("History.store"))||{}}catch(r){e={}}e.idToState=e.idToState||{},e.urlToId=e.urlToId||{},e.stateToId=e.stateToId||{};for(t in h.idToState){if(!h.idToState.hasOwnProperty(t))continue;e.idToState[t]=h.idToState[t]}for(t in h.urlToId){if(!h.urlToId.hasOwnProperty(t))continue;e.urlToId[t]=h.urlToId[t]}for(t in h.stateToId){if(!h.stateToId.hasOwnProperty(t))continue;e.stateToId[t]=h.stateToId[t]}h.store=e,h.normalizeStore(),n=l.stringify(e);try{s.setItem("History.store",n)}catch(i){if(i.code!==DOMException.QUOTA_EXCEEDED_ERR)throw i;s.length&&(s.removeItem("History.store"),s.setItem("History.store",n))}},h.intervalList.push(a(h.onUnload,h.options.storeInterval)),h.Adapter.bind(e,"beforeunload",h.onUnload),h.Adapter.bind(e,"unload",h.onUnload));if(!h.emulated.pushState){h.bugs.safariPoll&&h.intervalList.push(a(h.safariStatePoll,h.options.safariPollInterval));
if(i.vendor==="Apple Computer, Inc."||(i.appCodeName||"")==="Mozilla")h.Adapter.bind(e,"hashchange",function(){h.Adapter.trigger(e,"popstate")}),h.getHash()&&h.Adapter.onDomLoad(function(){h.Adapter.trigger(e,"hashchange")})}},(!h.options||!h.options.delayInit)&&h.init()}(window);/*#<![CDATA[*/
//-For version 2012.5.0
var sew_currentPreviewDIV=null;var sew_indexDirectory="";var sew_appPath="";var sew_previewLoadPlugin=false;var sew_maxCharLength="";function sew_toggleResultPreview(button,url,closedImgURL,openedImgURL){sew_currentPreviewDIV=KSQ(button).next();if(button.sew_opened==true){sew_currentPreviewDIV.hide("fast");button.src=closedImgURL;button.sew_opened=false}else{button.src=openedImgURL;button.sew_opened=true;sew_currentPreviewDIV.show("slow");KSQ.get(sew_appPath+"Keyoti.SearchEngine.Web.CallBackHandler.ashx?cl=SRP&u="+encodeURIComponent(url)+"&id="+encodeURIComponent(sew_indexDirectory)+"&p="+(sew_previewLoadPlugin?"1":"0")+"&mx="+sew_maxCharLength,function(data){if(sew_currentPreviewDIV!=null){if(typeof sew_OnResultPreviewTextLoaded=="function"){dataOut=sew_OnResultPreviewTextLoaded(url,data,button,closedImgURL,openedImgURL);if(dataOut!=null)data=dataOut}var text=data.replace(/</g,"&lt;");text=text.replace(/>/g,"&gt;");text=text.replace(/\n/g,"<br /><br />");//highlight
for(var k=0;k<sew_keywords.length;k++){text=text.replace(new RegExp("\\b("+sew_keywords[k]+")\\b","gi"),sew_keyword_highlightPattern.replace("{0}","$1"))}sew_currentPreviewDIV.html(text);sew_currentPreviewDIV=null}})}}
/*#<![CDATA[*/

var keyotiSearchHighlighter = {

    _getQueryStringParameters: function () {

        if (this._queryStringParameters == null) {
            this._queryStringParameters = {};
            if (window.location.search.length > 1) {
                this._queryStringParameters = this._parseQueryStringParameters(window.location.search);
            } else
                this._queryStringParameters = {};
        }
        return this._queryStringParameters;
    },

    _parseQueryStringParameters: function (qs) {
        var params = {};
        for (var aItKey, nKeyId = 0, aCouples = qs.substr(1).split("&") ; nKeyId < aCouples.length; nKeyId++) {
            aItKey = aCouples[nKeyId].split("=");
            params[decodeURIComponent(aItKey[0])] = aItKey.length > 1 ? decodeURIComponent(aItKey[1]) : "";
        }
        return params;
    },

    _isCssClassDefined: function(){
        for (var i = 0; i < document.styleSheets.length; i++) {
            var rules = document.styleSheets[i].cssRules;
            for (var j = 0; rules != null && j < rules.length; j++) {
                if (rules[j].cssText.indexOf("keyoti_highlight") > -1) return true;
            }
        }
        return false;
    },

    _highlight: function (keywords) {
        var isCSSDef = this._isCssClassDefined();
        var keywordPattern;
        RegExp.k_escape = function (text) {
            return text.replace(/[-[\]{}()*+?.,\\^$|#\s]/g, "\\$&");
        };
        for (var i = 0; i < keywords.length; i++) {


            if (keywords[i].length > 0) {
                var regWithBoundary = new RegExp("\\b(" + RegExp.k_escape(keywords[i]) + ")\\b", "gi");
                var regNoBoundary = new RegExp("(" + RegExp.k_escape(keywords[i]) + ")", "gi");
                if (/\w/.test(keywords[i].charAt(0)) && /\w/.test(keywords[i].charAt(keywords[i].length - 1))) {//the keyword starts and ends with a word char (otherwise \b boundary wont match)
                    // text = text.replace(regWithBoundary, this.keywordHighlightPattern.replace("{0}", "$1"));

                    keywordPattern = regWithBoundary;

                } else {
                    //no match, because the keyword starts with a non word character (eg + sign)
                    //text = text.replace(regNoBoundary, this.keywordHighlightPattern.replace("{0}", "$1"));
                    regWithBoundary = regNoBoundary;
                }
            }
            

            //keywordPattern = new RegExp("\\b" + keywords[i] + "\\b", "gi");
            if (document.body != null && keywords[i].length>0) {
                findAndReplaceDOMText(document.body, {
                    find: keywordPattern,
                    replace: function (portion, match) {
                        called = true;
                        var el = document.createElement('span');
                        el.className = "keyoti_highlight";
                        if (!isCSSDef) {
                            el.style.backgroundColor = "yellow";
							el.style.color = "black";
                        }
                        el.innerHTML = portion.text;
                        return el;
                    }
                });
            }
        }
    }

}

if(typeof(sew_highlighterOldOnLoad )=='undefined'){
	var sew_highlighterOldOnLoad = onload;
	onload = function () {
		if (typeof (sew_highlighterOldOnLoad) == 'function') sew_highlighterOldOnLoad();
		var keywordsQ = keyotiSearchHighlighter._getQueryStringParameters();
		if (keywordsQ != null) {
			var keywords = keywordsQ['searchunitkeywords'];
			if(keywords!=null)
				keyotiSearchHighlighter._highlight(keywords.split(","));
		}
	};
}



/**
* findAndReplaceDOMText v 0.4.2
* @author James Padolsey http://james.padolsey.com
* @license http://unlicense.org/UNLICENSE
*
* Matches the text of a DOM node against a regular expression
* and replaces each match (or node-separated portions of the match)
* in the specified element.
*/
window.findAndReplaceDOMText = (function () {

    var PORTION_MODE_RETAIN = 'retain';
    var PORTION_MODE_FIRST = 'first';

    var doc = document;
    var toString = {}.toString;

    function isArray(a) {
        return toString.call(a) == '[object Array]';
    }

    function escapeRegExp(s) {
        return String(s).replace(/([.*+?^=!:${}()|[\]\/\\])/g, '\\$1');
    }

    function exposed() {
        // Try deprecated arg signature first:
        return deprecated.apply(null, arguments) || findAndReplaceDOMText.apply(null, arguments);
    }

    function deprecated(regex, node, replacement, captureGroup, elFilter) {
        if ((node && !node.nodeType) && arguments.length <= 2) {
            return false;
        }
        var isReplacementFunction = typeof replacement == 'function';

        if (isReplacementFunction) {
            replacement = (function (original) {
                return function (portion, match) {
                    return original(portion.text, match.startIndex);
                };
            }(replacement));
        }

        // Awkward support for deprecated argument signature (<0.4.0)
        var instance = findAndReplaceDOMText(node, {

            find: regex,

            wrap: isReplacementFunction ? null : replacement,
            replace: isReplacementFunction ? replacement : '$' + (captureGroup || '&'),

            prepMatch: function (m, mi) {

                // Support captureGroup (a deprecated feature)

                if (!m[0]) throw 'findAndReplaceDOMText cannot handle zero-length matches';

                if (captureGroup > 0) {
                    var cg = m[captureGroup];
                    m.index += m[0].indexOf(cg);
                    m[0] = cg;
                }

                m.endIndex = m.index + m[0].length;
                m.startIndex = m.index;
                m.index = mi;

                return m;
            },
            filterElements: elFilter
        });

        exposed.revert = function () {
            return instance.revert();
        };

        return true;
    }

    /** 
     * findAndReplaceDOMText
     * 
     * Locates matches and replaces with replacementNode
     *
     * @param {Node} node Element or Text node to search within
     * @param {RegExp} options.find The regular expression to match
     * @param {String|Element} [options.wrap] A NodeName, or a Node to clone
     * @param {String|Function} [options.replace='$&'] What to replace each match with
     * @param {Function} [options.filterElements] A Function to be called to check whether to
     *	process an element. (returning true = process element,
     *	returning false = avoid element)
     */
    function findAndReplaceDOMText(node, options) {
        return new Finder(node, options);
    }

    exposed.Finder = Finder;

    /**
     * Finder -- encapsulates logic to find and replace.
     */
    function Finder(node, options) {

        options.portionMode = options.portionMode || PORTION_MODE_RETAIN;

        this.node = node;
        this.options = options;

        // ENable match-preparation method to be passed as option:
        this.prepMatch = options.prepMatch || this.prepMatch;

        this.reverts = [];

        this.matches = this.search();

        if (this.matches.length) {
            this.processMatches();
        }

    }

    Finder.prototype = {

        /**
         * Searches for all matches that comply with the instance's 'match' option
         */
        search: function () {

            var match;
            var matchIndex = 0;
            var regex = this.options.find;
            var text = this.getAggregateText();
            var matches = [];

            regex = typeof regex === 'string' ? RegExp(escapeRegExp(regex), 'g') : regex;

            if (regex.global) {
                while (match = regex.exec(text)) {
                    matches.push(this.prepMatch(match, matchIndex++));
                }
            } else {
                if (match = text.match(regex)) {
                    matches.push(this.prepMatch(match, 0));
                }
            }

            return matches;

        },

        /**
         * Prepares a single match with useful meta info:
         */
        prepMatch: function (match, matchIndex) {

            if (!match[0]) {
                throw new Error('findAndReplaceDOMText cannot handle zero-length matches');
            }

            match.endIndex = match.index + match[0].length;
            match.startIndex = match.index;
            match.index = matchIndex;

            return match;
        },

        /**
         * Gets aggregate text within subject node
         */
        getAggregateText: function () {

            var elementFilter = this.options.filterElements;

            return getText(this.node);

            /**
             * Gets aggregate text of a node without resorting
             * to broken innerText/textContent
             */
            function getText(node) {

                if (node.nodeType === 3) {
                    return node.data;
                }

                if (elementFilter && !elementFilter(node)) {
                    return '';
                }

                var txt = '';

                if (node = node.firstChild) do {
                    txt += getText(node);
                } while (node = node.nextSibling);

                return txt;

            }

        },

        /** 
         * Steps through the target node, looking for matches, and
         * calling replaceFn when a match is found.
         */
        processMatches: function () {

            var matches = this.matches;
            var node = this.node;
            var elementFilter = this.options.filterElements;

            var startPortion,
                endPortion,
                innerPortions = [],
                curNode = node,
                match = matches.shift(),
                atIndex = 0, // i.e. nodeAtIndex
                matchIndex = 0,
                portionIndex = 0,
                doAvoidNode,
                nodeStack = [node];

            out: while (true) {

                if (curNode.nodeType === 3) {

                    if (!endPortion && curNode.length + atIndex >= match.endIndex) {

                        // We've found the ending
                        endPortion = {
                            node: curNode,
                            index: portionIndex++,
                            text: curNode.data.substring(match.startIndex - atIndex, match.endIndex - atIndex),
                            indexInMatch: atIndex - match.startIndex,
                            indexInNode: match.startIndex - atIndex, // always zero for end-portions
                            endIndexInNode: match.endIndex - atIndex,
                            isEnd: true
                        };

                    } else if (startPortion) {
                        // Intersecting node
                        innerPortions.push({
                            node: curNode,
                            index: portionIndex++,
                            text: curNode.data,
                            indexInMatch: atIndex - match.startIndex,
                            indexInNode: 0 // always zero for inner-portions
                        });
                    }

                    if (!startPortion && curNode.length + atIndex > match.startIndex) {
                        // We've found the match start
                        startPortion = {
                            node: curNode,
                            index: portionIndex++,
                            indexInMatch: 0,
                            indexInNode: match.startIndex - atIndex,
                            endIndexInNode: match.endIndex - atIndex,
                            text: curNode.data.substring(match.startIndex - atIndex, match.endIndex - atIndex)
                        };
                    }

                    atIndex += curNode.data.length;

                }

                doAvoidNode = curNode.nodeType === 1 && elementFilter && !elementFilter(curNode);

                if (startPortion && endPortion) {

                    curNode = this.replaceMatch(match, startPortion, innerPortions, endPortion);

                    // processMatches has to return the node that replaced the endNode
                    // and then we step back so we can continue from the end of the 
                    // match:

                    atIndex -= (endPortion.node.data.length - endPortion.endIndexInNode);

                    startPortion = null;
                    endPortion = null;
                    innerPortions = [];
                    match = matches.shift();
                    portionIndex = 0;
                    matchIndex++;

                    if (!match) {
                        break; // no more matches
                    }

                } else if (
                    !doAvoidNode &&
                    (curNode.firstChild || curNode.nextSibling)
                ) {
                    // Move down or forward:
                    if (curNode.firstChild) {
                        nodeStack.push(curNode);
                        curNode = curNode.firstChild;
                    } else {
                        curNode = curNode.nextSibling;
                    }
                    continue;
                }

                // Move forward or up:
                while (true) {
                    if (curNode.nextSibling) {
                        curNode = curNode.nextSibling;
                        break;
                    }
                    curNode = nodeStack.pop();
                    if (curNode === node) {
                        break out;
                    }
                }

            }

        },

        /**
         * Reverts ... TODO
         */
        revert: function () {
            // Reversion occurs backwards so as to avoid nodes subsequently
            // replaced during the matching phase (a forward process):
            for (var l = this.reverts.length; l--;) {
                this.reverts[l]();
            }
            this.reverts = [];
        },

        prepareReplacementString: function (string, portion, match, matchIndex) {
            var portionMode = this.options.portionMode;
            if (
                portionMode === PORTION_MODE_FIRST &&
                portion.indexInMatch > 0
            ) {
                return '';
            }
            string = string.replace(/\$(\d+|&|`|')/g, function ($0, t) {
                var replacement;
                switch (t) {
                    case '&':
                        replacement = match[0];
                        break;
                    case '`':
                        replacement = match.input.substring(0, match.startIndex);
                        break;
                    case '\'':
                        replacement = match.input.substring(match.endIndex);
                        break;
                    default:
                        replacement = match[+t];
                }
                return replacement;
            });

            if (portionMode === PORTION_MODE_FIRST) {
                return string;
            }

            if (portion.isEnd) {
                return string.substring(portion.indexInMatch);
            }

            return string.substring(portion.indexInMatch, portion.indexInMatch + portion.text.length);
        },

        getPortionReplacementNode: function (portion, match, matchIndex) {

            var replacement = this.options.replace || '$&';
            var wrapper = this.options.wrap;

            if (wrapper && wrapper.nodeType) {
                // Wrapper has been provided as a stencil-node for us to clone:
                var clone = doc.createElement('div');
                clone.innerHTML = wrapper.outerHTML || new XMLSerializer().serializeToString(wrapper);
                wrapper = clone.firstChild;
            }

            if (typeof replacement == 'function') {
                replacement = replacement(portion, match, matchIndex);
                if (replacement && replacement.nodeType) {
                    return replacement;
                }
                return doc.createTextNode(String(replacement));
            }

            var el = typeof wrapper == 'string' ? doc.createElement(wrapper) : wrapper;

            replacement = doc.createTextNode(
                this.prepareReplacementString(
                    replacement, portion, match, matchIndex
                )
            );

            if (!replacement.data) {
                return replacement;
            }

            if (!el) {
                return replacement;
            }

            el.appendChild(replacement);

            return el;
        },

        replaceMatch: function (match, startPortion, innerPortions, endPortion) {

            var matchStartNode = startPortion.node;
            var matchEndNode = endPortion.node;

            var preceedingTextNode;
            var followingTextNode;

            if (matchStartNode === matchEndNode) {

                var node = matchStartNode;

                if (startPortion.indexInNode > 0) {
                    // Add `before` text node (before the match)
                    preceedingTextNode = doc.createTextNode(node.data.substring(0, startPortion.indexInNode));
                    node.parentNode.insertBefore(preceedingTextNode, node);
                }

                // Create the replacement node:
                var newNode = this.getPortionReplacementNode(
                    endPortion,
                    match
                );

                node.parentNode.insertBefore(newNode, node);

                if (endPortion.endIndexInNode < node.length) { // ?????
                    // Add `after` text node (after the match)
                    followingTextNode = doc.createTextNode(node.data.substring(endPortion.endIndexInNode));
                    node.parentNode.insertBefore(followingTextNode, node);
                }

                node.parentNode.removeChild(node);

                this.reverts.push(function () {
                    if (preceedingTextNode === newNode.previousSibling) {
                        preceedingTextNode.parentNode.removeChild(preceedingTextNode);
                    }
                    if (followingTextNode === newNode.nextSibling) {
                        followingTextNode.parentNode.removeChild(followingTextNode);
                    }
                    newNode.parentNode.replaceChild(node, newNode);
                });

                return newNode;

            } else {
                // Replace matchStartNode -> [innerMatchNodes...] -> matchEndNode (in that order)


                preceedingTextNode = doc.createTextNode(
                    matchStartNode.data.substring(0, startPortion.indexInNode)
                );

                followingTextNode = doc.createTextNode(
                    matchEndNode.data.substring(endPortion.endIndexInNode)
                );

                var firstNode = this.getPortionReplacementNode(
                    startPortion,
                    match
                );

                var innerNodes = [];

                for (var i = 0, l = innerPortions.length; i < l; ++i) {
                    var portion = innerPortions[i];
                    var innerNode = this.getPortionReplacementNode(
                        portion,
                        match
                    );
                    portion.node.parentNode.replaceChild(innerNode, portion.node);
                    this.reverts.push((function (portion, innerNode) {
                        return function () {
                            innerNode.parentNode.replaceChild(portion.node, innerNode);
                        };
                    }(portion, innerNode)));
                    innerNodes.push(innerNode);
                }

                var lastNode = this.getPortionReplacementNode(
                    endPortion,
                    match
                );

                matchStartNode.parentNode.insertBefore(preceedingTextNode, matchStartNode);
                matchStartNode.parentNode.insertBefore(firstNode, matchStartNode);
                matchStartNode.parentNode.removeChild(matchStartNode);

                matchEndNode.parentNode.insertBefore(lastNode, matchEndNode);
                matchEndNode.parentNode.insertBefore(followingTextNode, matchEndNode);
                matchEndNode.parentNode.removeChild(matchEndNode);

                this.reverts.push(function () {
                    preceedingTextNode.parentNode.removeChild(preceedingTextNode);
                    firstNode.parentNode.replaceChild(matchStartNode, firstNode);
                    followingTextNode.parentNode.removeChild(followingTextNode);
                    lastNode.parentNode.replaceChild(matchEndNode, lastNode);
                });

                return lastNode;
            }
        }

    };

    return exposed;

}());
/* ]]> */

/*#<![CDATA[*/
/*
 * jQuery UI 1.6
 *
 * Copyright (c) 2008 AUTHORS.txt (http://ui.jquery.com/about)
 * Dual licensed under the MIT (MIT-LICENSE.txt)
 * and GPL (GPL-LICENSE.txt) licenses.
 *
 * http://docs.jquery.com/UI
 */
(function (C) {
    var I = C.fn.remove, D = C.browser.mozilla && (parseFloat(C.browser.version) < 1.9); C.ui = {
        version: "1.6", plugin: { add: function (K, L, N) { var M = C.ui[K].prototype; for (var J in N) { M.plugins[J] = M.plugins[J] || []; M.plugins[J].push([L, N[J]]) } }, call: function (J, L, K) { var N = J.plugins[L]; if (!N) { return } for (var M = 0; M < N.length; M++) { if (J.options[N[M][0]]) { N[M][1].apply(J.element, K) } } } }, contains: function (L, K) { var J = C.browser.safari && C.browser.version < 522; if (L.contains && !J) { return L.contains(K) } if (L.compareDocumentPosition) { return !!(L.compareDocumentPosition(K) & 16) } while (K = K.parentNode) { if (K == L) { return true } } return false }, cssCache: {}, css: function (J) { if (C.ui.cssCache[J]) { return C.ui.cssCache[J] } var K = C('<div class="ui-gen">').addClass(J).css({ position: "absolute", top: "-5000px", left: "-5000px", display: "block" }).appendTo("body"); C.ui.cssCache[J] = !!((!(/auto|default/).test(K.css("cursor")) || (/^[1-9]/).test(K.css("height")) || (/^[1-9]/).test(K.css("width")) || !(/none/).test(K.css("backgroundImage")) || !(/transparent|rgba\(0, 0, 0, 0\)/).test(K.css("backgroundColor")))); try { C("body").get(0).removeChild(K.get(0)) } catch (L) { } return C.ui.cssCache[J] }, hasScroll: function (M, K) { if (C(M).css("overflow") == "hidden") { return false } var J = (K && K == "left") ? "scrollLeft" : "scrollTop", L = false; if (M[J] > 0) { return true } M[J] = 1; L = (M[J] > 0); M[J] = 0; return L }, isOverAxis: function (K, J, L) { return (K > J) && (K < (J + L)) }, isOver: function (O, K, N, M, J, L) {
            return C.ui.isOverAxis(O, N, J) && C.ui.isOverAxis(K, M, L)
        }, keyCode: { BACKSPACE: 8, CAPS_LOCK: 20, COMMA: 188, CONTROL: 17, DELETE: 46, DOWN: 40, END: 35, ENTER: 13, ESCAPE: 27, HOME: 36, INSERT: 45, LEFT: 37, NUMPAD_ADD: 107, NUMPAD_DECIMAL: 110, NUMPAD_DIVIDE: 111, NUMPAD_ENTER: 108, NUMPAD_MULTIPLY: 106, NUMPAD_SUBTRACT: 109, PAGE_DOWN: 34, PAGE_UP: 33, PERIOD: 190, RIGHT: 39, SHIFT: 16, SPACE: 32, TAB: 9, UP: 38 }
    }; if (D) { var F = C.attr, E = C.fn.removeAttr, H = "http://www.w3.org/2005/07/aaa", A = /^aria-/, B = /^wairole:/; C.attr = function (K, J, L) { var M = L !== undefined; return (J == "role" ? (M ? F.call(this, K, J, "wairole:" + L) : (F.apply(this, arguments) || "").replace(B, "")) : (A.test(J) ? (M ? K.setAttributeNS(H, J.replace(A, "aaa:"), L) : F.call(this, K, J.replace(A, "aaa:"))) : F.apply(this, arguments))) }; C.fn.removeAttr = function (J) { return (A.test(J) ? this.each(function () { this.removeAttributeNS(H, J.replace(A, "")) }) : E.call(this, J)) } } C.fn.extend({ remove: function () { C("*", this).add(this).each(function () { C(this).triggerHandler("remove") }); return I.apply(this, arguments) }, enableSelection: function () { return this.attr("unselectable", "off").css("MozUserSelect", "").unbind("selectstart.ui") }, disableSelection: function () { return this.attr("unselectable", "on").css("MozUserSelect", "none").bind("selectstart.ui", function () { return false }) }, scrollParent: function () { var J; if ((C.browser.msie && (/(static|relative)/).test(this.css("position"))) || (/absolute/).test(this.css("position"))) { J = this.parents().filter(function () { return (/(relative|absolute|fixed)/).test(C.curCSS(this, "position", 1)) && (/(auto|scroll)/).test(C.curCSS(this, "overflow", 1) + C.curCSS(this, "overflow-y", 1) + C.curCSS(this, "overflow-x", 1)) }).eq(0) } else { J = this.parents().filter(function () { return (/(auto|scroll)/).test(C.curCSS(this, "overflow", 1) + C.curCSS(this, "overflow-y", 1) + C.curCSS(this, "overflow-x", 1)) }).eq(0) } return (/fixed/).test(this.css("position")) || !J.length ? C(document) : J } }); C.extend(C.expr[":"], { data: function (K, L, J) { return C.data(K, J[3]) }, tabbable: function (L, M, K) { var N = L.nodeName.toLowerCase(); function J(O) { return !(C(O).is(":hidden") || C(O).parents(":hidden").length) } return (L.tabIndex >= 0 && (("a" == N && L.href) || (/input|select|textarea|button/.test(N) && "hidden" != L.type && !L.disabled)) && J(L)) } });
    function G(M, N, O, L) { function K(Q) { var P = C[M][N][Q] || []; return (typeof P == "string" ? P.split(/,?\s+/) : P) } var J = K("getter"); if (L.length == 1 && typeof L[0] == "string") { J = J.concat(K("getterSetter")) } return (C.inArray(O, J) != -1) } C.widget = function (K, J) { var L = K.split(".")[0]; K = K.split(".")[1]; C.fn[K] = function (P) { var N = (typeof P == "string"), O = Array.prototype.slice.call(arguments, 1); if (N && P.substring(0, 1) == "_") { return this } if (N && G(L, K, P, O)) { var M = C.data(this[0], K); return (M ? M[P].apply(M, O) : undefined) } return this.each(function () { var Q = C.data(this, K); (!Q && !N && C.data(this, K, new C[L][K](this, P))); (Q && N && C.isFunction(Q[P]) && Q[P].apply(Q, O)) }) }; C[L] = C[L] || {}; C[L][K] = function (O, N) { var M = this; this.widgetName = K; this.widgetEventPrefix = C[L][K].eventPrefix || K; this.widgetBaseClass = L + "-" + K; this.options = C.extend({}, C.widget.defaults, C[L][K].defaults, C.metadata && C.metadata.get(O)[K], N); this.element = C(O).bind("setData." + K, function (Q, P, R) { return M._setData(P, R) }).bind("getData." + K, function (Q, P) { return M._getData(P) }).bind("remove", function () { return M.destroy() }); this._init() }; C[L][K].prototype = C.extend({}, C.widget.prototype, J); C[L][K].getterSetter = "option" }; C.widget.prototype = {
        _init: function () { }, destroy: function () { this.element.removeData(this.widgetName) },
        option: function (L, M) { var K = L, J = this; if (typeof L == "string") { if (M === undefined) { return this._getData(L) } K = {}; K[L] = M } C.each(K, function (N, O) { J._setData(N, O) }) }, _getData: function (J) { return this.options[J] }, _setData: function (J, K) { this.options[J] = K; if (J == "disabled") { this.element[K ? "addClass" : "removeClass"](this.widgetBaseClass + "-disabled") } }, enable: function () { this._setData("disabled", false) }, disable: function () { this._setData("disabled", true) }, _trigger: function (K, L, M) { var J = (K == this.widgetEventPrefix ? K : this.widgetEventPrefix + K); L = L || C.event.fix({ type: J, target: this.element[0] }); return this.element.triggerHandler(J, [L, M], this.options[K]) }
    }; C.widget.defaults = { disabled: false }; C.ui.mouse = { _mouseInit: function () { var J = this; this.element.bind("mousedown." + this.widgetName, function (K) { return J._mouseDown(K) }).bind("click." + this.widgetName, function (K) { if (J._preventClickEvent) { J._preventClickEvent = false; return false } }); if (C.browser.msie) { this._mouseUnselectable = this.element.attr("unselectable"); this.element.attr("unselectable", "on") } this.started = false }, _mouseDestroy: function () { this.element.unbind("." + this.widgetName); (C.browser.msie && this.element.attr("unselectable", this._mouseUnselectable)) }, _mouseDown: function (L) { (this._mouseStarted && this._mouseUp(L)); this._mouseDownEvent = L; var K = this, M = (L.which == 1), J = (typeof this.options.cancel == "string" ? C(L.target).parents().add(L.target).filter(this.options.cancel).length : false); if (!M || J || !this._mouseCapture(L)) { return true } this.mouseDelayMet = !this.options.delay; if (!this.mouseDelayMet) { this._mouseDelayTimer = setTimeout(function () { K.mouseDelayMet = true }, this.options.delay) } if (this._mouseDistanceMet(L) && this._mouseDelayMet(L)) { this._mouseStarted = (this._mouseStart(L) !== false); if (!this._mouseStarted) { L.preventDefault(); return true } } this._mouseMoveDelegate = function (N) { return K._mouseMove(N) }; this._mouseUpDelegate = function (N) { return K._mouseUp(N) }; C(document).bind("mousemove." + this.widgetName, this._mouseMoveDelegate).bind("mouseup." + this.widgetName, this._mouseUpDelegate); if (!C.browser.safari) { L.preventDefault() } return true }, _mouseMove: function (J) { if (C.browser.msie && !J.button) { return this._mouseUp(J) } if (this._mouseStarted) { this._mouseDrag(J); return J.preventDefault() } if (this._mouseDistanceMet(J) && this._mouseDelayMet(J)) { this._mouseStarted = (this._mouseStart(this._mouseDownEvent, J) !== false); (this._mouseStarted ? this._mouseDrag(J) : this._mouseUp(J)) } return !this._mouseStarted }, _mouseUp: function (J) { C(document).unbind("mousemove." + this.widgetName, this._mouseMoveDelegate).unbind("mouseup." + this.widgetName, this._mouseUpDelegate); if (this._mouseStarted) { this._mouseStarted = false; this._preventClickEvent = true; this._mouseStop(J) } return false }, _mouseDistanceMet: function (J) { return (Math.max(Math.abs(this._mouseDownEvent.pageX - J.pageX), Math.abs(this._mouseDownEvent.pageY - J.pageY)) >= this.options.distance) }, _mouseDelayMet: function (J) { return this.mouseDelayMet }, _mouseStart: function (J) { }, _mouseDrag: function (J) { }, _mouseStop: function (J) { }, _mouseCapture: function (J) { return true } }; C.ui.mouse.defaults = { cancel: null, distance: 1, delay: 0 }
})(KSQ);

/* ]]> */

/*#<![CDATA[*/
/*
 * KSQ UI Datepicker 1.6
 *
 * Copyright (c) 2008 AUTHORS.txt (http://ui.KSQ.com/about)
 * Dual licensed under the MIT (MIT-LICENSE.txt)
 * and GPL (GPL-LICENSE.txt) licenses.
 *
 * http://docs.KSQ.com/UI/Datepicker
 *
 * Depends:
 *	ui.core.js
 */
(function ($) {
    $.extend($.ui, { datepicker: { version: "1.6" } }); var PROP_NAME = "datepicker"; function Datepicker() {
        this.debug = false; this._curInst = null; this._keyEvent = false; this._disabledInputs = []; this._datepickerShowing = false; this._inDialog = false; this._mainDivId = "ui-datepicker-div"; this._inlineClass = "ui-datepicker-inline"; this._appendClass = "ui-datepicker-append"; this._triggerClass = "ui-datepicker-trigger"; this._dialogClass = "ui-datepicker-dialog"; this._promptClass = "ui-datepicker-prompt"; this._disableClass = "ui-datepicker-disabled"; this._unselectableClass = "ui-datepicker-unselectable"; this._currentClass = "ui-datepicker-current-day"; this._dayOverClass = "ui-datepicker-days-cell-over"; this._weekOverClass = "ui-datepicker-week-over"; this.regional = []; this.regional[""] = { clearText: "Clear", clearStatus: "Erase the current date", closeText: "Close", closeStatus: "Close without change", prevText: "&#x3c;Prev", prevStatus: "Show the previous month", prevBigText: "&#x3c;&#x3c;", prevBigStatus: "Show the previous year", nextText: "Next&#x3e;", nextStatus: "Show the next month", nextBigText: "&#x3e;&#x3e;", nextBigStatus: "Show the next year", currentText: "Today", currentStatus: "Show the current month", monthNames: ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"], monthNamesShort: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"], monthStatus: "Show a different month", yearStatus: "Show a different year", weekHeader: "Wk", weekStatus: "Week of the year", dayNames: ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"], dayNamesShort: ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"], dayNamesMin: ["Su", "Mo", "Tu", "We", "Th", "Fr", "Sa"], dayStatus: "Set DD as first week day", dateStatus: "Select DD, M d", dateFormat: "mm/dd/yy", firstDay: 0, initStatus: "Select a date", isRTL: false }; this._defaults = { showOn: "focus", showAnim: "show", showOptions: {}, defaultDate: null, appendText: "", buttonText: "...", buttonImage: "", buttonImageOnly: false, closeAtTop: true, mandatory: false, hideIfNoPrevNext: false, navigationAsDateFormat: false, showBigPrevNext: false, gotoCurrent: false, changeMonth: true, changeYear: true, showMonthAfterYear: false, yearRange: "-10:+10", changeFirstDay: true, highlightWeek: false, showOtherMonths: false, showWeeks: false, calculateWeek: this.iso8601Week, shortYearCutoff: "+10", showStatus: false, statusForDate: this.dateStatus, minDate: null, maxDate: null, duration: "normal", beforeShowDay: null, beforeShow: null, onSelect: null, onChangeMonthYear: null, onClose: null, numberOfMonths: 1, showCurrentAtPos: 0, stepMonths: 1, stepBigMonths: 12, rangeSelect: false, rangeSeparator: " - ", altField: "", altFormat: "", constrainInput: true }; $.extend(this._defaults, this.regional[""]);
        this.dpDiv = $('<div id="' + this._mainDivId + '" style="display: none;"></div>')
    } $.extend(Datepicker.prototype, {
        markerClassName: "hasDatepicker", log: function () { if (this.debug) { console.log.apply("", arguments) } }, setDefaults: function (settings) { extendRemove(this._defaults, settings || {}); return this }, _attachDatepicker: function (target, settings) {
            var inlineSettings = null; for (var attrName in this._defaults) { var attrValue = target.getAttribute("date:" + attrName); if (attrValue) { inlineSettings = inlineSettings || {}; try { inlineSettings[attrName] = eval(attrValue) } catch (err) { inlineSettings[attrName] = attrValue } } } var nodeName = target.nodeName.toLowerCase(); var inline = (nodeName == "div" || nodeName == "span"); if (!target.id) { target.id = "dp" + (++this.uuid) } var inst = this._newInst($(target), inline); inst.settings = $.extend({}, settings || {}, inlineSettings || {}); if (nodeName == "input") { this._connectDatepicker(target, inst) } else {
                if (inline) { this._inlineDatepicker(target, inst) }
            }
        }, _newInst: function (target, inline) { var id = target[0].id.replace(/([:\[\]\.])/g, "\\\\$1"); return { id: id, input: target, selectedDay: 0, selectedMonth: 0, selectedYear: 0, drawMonth: 0, drawYear: 0, inline: inline, dpDiv: (!inline ? this.dpDiv : $('<div class="' + this._inlineClass + '"></div>')) } }, _connectDatepicker: function (target, inst) { var input = $(target); if (input.hasClass(this.markerClassName)) { return } var appendText = this._get(inst, "appendText"); var isRTL = this._get(inst, "isRTL"); if (appendText) { input[isRTL ? "before" : "after"]('<span class="' + this._appendClass + '">' + appendText + "</span>") } var showOn = this._get(inst, "showOn"); if (showOn == "focus" || showOn == "both") { input.focus(this._showDatepicker) } if (showOn == "button" || showOn == "both") { var buttonText = this._get(inst, "buttonText"); var buttonImage = this._get(inst, "buttonImage"); var trigger = $(this._get(inst, "buttonImageOnly") ? $("<img/>").addClass(this._triggerClass).attr({ src: buttonImage, alt: buttonText, title: buttonText }) : $('<button type="button"></button>').addClass(this._triggerClass).html(buttonImage == "" ? buttonText : $("<img/>").attr({ src: buttonImage, alt: buttonText, title: buttonText }))); input[isRTL ? "before" : "after"](trigger); trigger.click(function () { if ($.datepicker._datepickerShowing && $.datepicker._lastInput == target) { $.datepicker._hideDatepicker() } else { $.datepicker._showDatepicker(target) } return false }) } input.addClass(this.markerClassName).keydown(this._doKeyDown).keypress(this._doKeyPress).bind("setData.datepicker", function (event, key, value) { inst.settings[key] = value }).bind("getData.datepicker", function (event, key) { return this._get(inst, key) }); $.data(target, PROP_NAME, inst) }, _inlineDatepicker: function (target, inst) { var divSpan = $(target); if (divSpan.hasClass(this.markerClassName)) { return } divSpan.addClass(this.markerClassName).append(inst.dpDiv).bind("setData.datepicker", function (event, key, value) { inst.settings[key] = value }).bind("getData.datepicker", function (event, key) { return this._get(inst, key) }); $.data(target, PROP_NAME, inst); this._setDate(inst, this._getDefaultDate(inst)); this._updateDatepicker(inst); this._updateAlternate(inst) }, _dialogDatepicker: function (input, dateText, onSelect, settings, pos) {
            var inst = this._dialogInst; if (!inst) { var id = "dp" + (++this.uuid); this._dialogInput = $('<input type="text" id="' + id + '" size="1" style="position: absolute; top: -100px;"/>'); this._dialogInput.keydown(this._doKeyDown); $("body").append(this._dialogInput); inst = this._dialogInst = this._newInst(this._dialogInput, false); inst.settings = {}; $.data(this._dialogInput[0], PROP_NAME, inst) } extendRemove(inst.settings, settings || {});
            this._dialogInput.val(dateText); this._pos = (pos ? (pos.length ? pos : [pos.pageX, pos.pageY]) : null); if (!this._pos) { var browserWidth = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth; var browserHeight = window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight; var scrollX = document.documentElement.scrollLeft || document.body.scrollLeft; var scrollY = document.documentElement.scrollTop || document.body.scrollTop; this._pos = [(browserWidth / 2) - 100 + scrollX, (browserHeight / 2) - 150 + scrollY] } this._dialogInput.css("left", this._pos[0] + "px").css("top", this._pos[1] + "px"); inst.settings.onSelect = onSelect; this._inDialog = true; this.dpDiv.addClass(this._dialogClass); this._showDatepicker(this._dialogInput[0]); if ($.blockUI) { $.blockUI(this.dpDiv) } $.data(this._dialogInput[0], PROP_NAME, inst); return this
        }, _destroyDatepicker: function (target) { var $target = $(target); if (!$target.hasClass(this.markerClassName)) { return } var nodeName = target.nodeName.toLowerCase(); $.removeData(target, PROP_NAME); if (nodeName == "input") { $target.siblings("." + this._appendClass).remove().end().siblings("." + this._triggerClass).remove().end().removeClass(this.markerClassName).unbind("focus", this._showDatepicker).unbind("keydown", this._doKeyDown).unbind("keypress", this._doKeyPress) } else { if (nodeName == "div" || nodeName == "span") { $target.removeClass(this.markerClassName).empty() } } }, _enableDatepicker: function (target) { var $target = $(target); if (!$target.hasClass(this.markerClassName)) { return } var nodeName = target.nodeName.toLowerCase(); if (nodeName == "input") { target.disabled = false; $target.siblings("button." + this._triggerClass).each(function () { this.disabled = false }).end().siblings("img." + this._triggerClass).css({ opacity: "1.0", cursor: "" }) } else { if (nodeName == "div" || nodeName == "span") { $target.children("." + this._disableClass).remove() } } this._disabledInputs = $.map(this._disabledInputs, function (value) { return (value == target ? null : value) }) }, _disableDatepicker: function (target) { var $target = $(target); if (!$target.hasClass(this.markerClassName)) { return } var nodeName = target.nodeName.toLowerCase(); if (nodeName == "input") { target.disabled = true; $target.siblings("button." + this._triggerClass).each(function () { this.disabled = true }).end().siblings("img." + this._triggerClass).css({ opacity: "0.5", cursor: "default" }) } else { if (nodeName == "div" || nodeName == "span") { var inline = $target.children("." + this._inlineClass); var offset = inline.offset(); var relOffset = { left: 0, top: 0 }; inline.parents().each(function () { if ($(this).css("position") == "relative") { relOffset = $(this).offset(); return false } }); $target.prepend('<div class="' + this._disableClass + '" style="' + ($.browser.msie ? "background-color: transparent; " : "") + "width: " + inline.width() + "px; height: " + inline.height() + "px; left: " + (offset.left - relOffset.left) + "px; top: " + (offset.top - relOffset.top) + 'px;"></div>') } } this._disabledInputs = $.map(this._disabledInputs, function (value) { return (value == target ? null : value) }); this._disabledInputs[this._disabledInputs.length] = target }, _isDisabledDatepicker: function (target) { if (!target) { return false } for (var i = 0; i < this._disabledInputs.length; i++) { if (this._disabledInputs[i] == target) { return true } } return false }, _getInst: function (target) { try { return $.data(target, PROP_NAME) } catch (err) { throw "Missing instance data for this datepicker" } }, _optionDatepicker: function (target, name, value) {
            var settings = name || {}; if (typeof name == "string") { settings = {}; settings[name] = value } var inst = this._getInst(target); if (inst) {
                if (this._curInst == inst) { this._hideDatepicker(null) } extendRemove(inst.settings, settings);
                var date = new Date(); extendRemove(inst, { rangeStart: null, endDay: null, endMonth: null, endYear: null, selectedDay: date.getDate(), selectedMonth: date.getMonth(), selectedYear: date.getFullYear(), currentDay: date.getDate(), currentMonth: date.getMonth(), currentYear: date.getFullYear(), drawMonth: date.getMonth(), drawYear: date.getFullYear() }); this._updateDatepicker(inst)
            }
        }, _changeDatepicker: function (target, name, value) { this._optionDatepicker(target, name, value) }, _refreshDatepicker: function (target) { var inst = this._getInst(target); if (inst) { this._updateDatepicker(inst) } }, _setDateDatepicker: function (target, date, endDate) { var inst = this._getInst(target); if (inst) { this._setDate(inst, date, endDate); this._updateDatepicker(inst); this._updateAlternate(inst) } }, _getDateDatepicker: function (target) { var inst = this._getInst(target); if (inst && !inst.inline) { this._setDateFromField(inst) } return (inst ? this._getDate(inst) : null) }, _doKeyDown: function (event) {
            var inst = $.datepicker._getInst(event.target); var handled = true; inst._keyEvent = true; if ($.datepicker._datepickerShowing) { switch (event.keyCode) { case 9: $.datepicker._hideDatepicker(null, ""); break; case 13: var sel = $("td." + $.datepicker._dayOverClass + ", td." + $.datepicker._currentClass, inst.dpDiv); if (sel[0]) { $.datepicker._selectDay(event.target, inst.selectedMonth, inst.selectedYear, sel[0]) } else { $.datepicker._hideDatepicker(null, $.datepicker._get(inst, "duration")) } return false; break; case 27: $.datepicker._hideDatepicker(null, $.datepicker._get(inst, "duration")); break; case 33: $.datepicker._adjustDate(event.target, (event.ctrlKey ? -$.datepicker._get(inst, "stepBigMonths") : -$.datepicker._get(inst, "stepMonths")), "M"); break; case 34: $.datepicker._adjustDate(event.target, (event.ctrlKey ? +$.datepicker._get(inst, "stepBigMonths") : +$.datepicker._get(inst, "stepMonths")), "M"); break; case 35: if (event.ctrlKey || event.metaKey) { $.datepicker._clearDate(event.target) } handled = event.ctrlKey || event.metaKey; break; case 36: if (event.ctrlKey || event.metaKey) { $.datepicker._gotoToday(event.target) } handled = event.ctrlKey || event.metaKey; break; case 37: if (event.ctrlKey || event.metaKey) { $.datepicker._adjustDate(event.target, -1, "D") } handled = event.ctrlKey || event.metaKey; if (event.originalEvent.altKey) { $.datepicker._adjustDate(event.target, (event.ctrlKey ? -$.datepicker._get(inst, "stepBigMonths") : -$.datepicker._get(inst, "stepMonths")), "M") } break; case 38: if (event.ctrlKey || event.metaKey) { $.datepicker._adjustDate(event.target, -7, "D") } handled = event.ctrlKey || event.metaKey; break; case 39: if (event.ctrlKey || event.metaKey) { $.datepicker._adjustDate(event.target, +1, "D") } handled = event.ctrlKey || event.metaKey; if (event.originalEvent.altKey) { $.datepicker._adjustDate(event.target, (event.ctrlKey ? +$.datepicker._get(inst, "stepBigMonths") : +$.datepicker._get(inst, "stepMonths")), "M") } break; case 40: if (event.ctrlKey || event.metaKey) { $.datepicker._adjustDate(event.target, +7, "D") } handled = event.ctrlKey || event.metaKey; break; default: handled = false } } else {
                if (event.keyCode == 36 && event.ctrlKey) { $.datepicker._showDatepicker(this) } else { handled = false }
            } if (handled) { event.preventDefault(); event.stopPropagation() }
        }, _doKeyPress: function (event) {
            var inst = $.datepicker._getInst(event.target); if ($.datepicker._get(inst, "constrainInput")) { var chars = $.datepicker._possibleChars($.datepicker._get(inst, "dateFormat")); var chr = String.fromCharCode(event.charCode == undefined ? event.keyCode : event.charCode); return event.ctrlKey || (chr < " " || !chars || chars.indexOf(chr) > -1) }
        }, _showDatepicker: function (input) { input = input.target || input; if (input.nodeName.toLowerCase() != "input") { input = $("input", input.parentNode)[0] } if ($.datepicker._isDisabledDatepicker(input) || $.datepicker._lastInput == input) { return } var inst = $.datepicker._getInst(input); var beforeShow = $.datepicker._get(inst, "beforeShow"); extendRemove(inst.settings, (beforeShow ? beforeShow.apply(input, [input, inst]) : {})); $.datepicker._hideDatepicker(null, ""); $.datepicker._lastInput = input; $.datepicker._setDateFromField(inst); if ($.datepicker._inDialog) { input.value = "" } if (!$.datepicker._pos) { $.datepicker._pos = $.datepicker._findPos(input); $.datepicker._pos[1] += input.offsetHeight } var isFixed = false; $(input).parents().each(function () { isFixed |= $(this).css("position") == "fixed"; return !isFixed }); if (isFixed && $.browser.opera) { $.datepicker._pos[0] -= document.documentElement.scrollLeft; $.datepicker._pos[1] -= document.documentElement.scrollTop } var offset = { left: $.datepicker._pos[0], top: $.datepicker._pos[1] }; $.datepicker._pos = null; inst.rangeStart = null; inst.dpDiv.css({ position: "absolute", display: "block", top: "-1000px" }); $.datepicker._updateDatepicker(inst); inst.dpDiv.width($.datepicker._getNumberOfMonths(inst)[1] * $(".ui-datepicker", inst.dpDiv[0])[0].offsetWidth); offset = $.datepicker._checkOffset(inst, offset, isFixed); inst.dpDiv.css({ position: ($.datepicker._inDialog && $.blockUI ? "static" : (isFixed ? "fixed" : "absolute")), display: "none", left: offset.left + "px", top: offset.top + "px" }); if (!inst.inline) { var showAnim = $.datepicker._get(inst, "showAnim") || "show"; var duration = $.datepicker._get(inst, "duration"); var postProcess = function () { $.datepicker._datepickerShowing = true; if ($.browser.msie && parseInt($.browser.version, 10) < 7) { $("iframe.ui-datepicker-cover").css({ width: inst.dpDiv.width() + 4, height: inst.dpDiv.height() + 4 }) } }; if ($.effects && $.effects[showAnim]) { inst.dpDiv.show(showAnim, $.datepicker._get(inst, "showOptions"), duration, postProcess) } else { inst.dpDiv[showAnim](duration, postProcess) } if (duration == "") { postProcess() } if (inst.input[0].type != "hidden") { inst.input[0].focus() } $.datepicker._curInst = inst } }, _updateDatepicker: function (inst) { var dims = { width: inst.dpDiv.width() + 4, height: inst.dpDiv.height() + 4 }; inst.dpDiv.empty().append(this._generateHTML(inst)).find("iframe.ui-datepicker-cover").css({ width: dims.width, height: dims.height }); var numMonths = this._getNumberOfMonths(inst); inst.dpDiv[(numMonths[0] != 1 || numMonths[1] != 1 ? "add" : "remove") + "Class"]("ui-datepicker-multi"); inst.dpDiv[(this._get(inst, "isRTL") ? "add" : "remove") + "Class"]("ui-datepicker-rtl"); if (inst.input && inst.input[0].type != "hidden" && inst == $.datepicker._curInst) { $(inst.input[0]).focus() } }, _checkOffset: function (inst, offset, isFixed) {
            var pos = inst.input ? this._findPos(inst.input[0]) : null;
            var browserWidth = window.innerWidth || (document.documentElement ? document.documentElement.clientWidth : document.body.clientWidth); var browserHeight = window.innerHeight || (document.documentElement ? document.documentElement.clientHeight : document.body.clientHeight); var scrollX = document.documentElement.scrollLeft || document.body.scrollLeft; var scrollY = document.documentElement.scrollTop || document.body.scrollTop; if (this._get(inst, "isRTL") || (offset.left + inst.dpDiv.width() - scrollX) > browserWidth) { offset.left = Math.max((isFixed ? 0 : scrollX), pos[0] + (inst.input ? inst.input.width() : 0) - (isFixed ? scrollX : 0) - inst.dpDiv.width() - (isFixed && $.browser.opera ? document.documentElement.scrollLeft : 0)) } else { offset.left -= (isFixed ? scrollX : 0) } if ((offset.top + inst.dpDiv.height() - scrollY) > browserHeight) { offset.top = Math.max((isFixed ? 0 : scrollY), pos[1] - (isFixed ? scrollY : 0) - (this._inDialog ? 0 : inst.dpDiv.height()) - (isFixed && $.browser.opera ? document.documentElement.scrollTop : 0)) } else { offset.top -= (isFixed ? scrollY : 0) } return offset
        }, _findPos: function (obj) { while (obj && (obj.type == "hidden" || obj.nodeType != 1)) { obj = obj.nextSibling } var position = $(obj).offset(); return [position.left, position.top] }, _hideDatepicker: function (input, duration) { var inst = this._curInst; if (!inst || (input && inst != $.data(input, PROP_NAME))) { return } var rangeSelect = this._get(inst, "rangeSelect"); if (rangeSelect && inst.stayOpen) { this._selectDate("#" + inst.id, this._formatDate(inst, inst.currentDay, inst.currentMonth, inst.currentYear)) } inst.stayOpen = false; if (this._datepickerShowing) { duration = (duration != null ? duration : this._get(inst, "duration")); var showAnim = this._get(inst, "showAnim"); var postProcess = function () { $.datepicker._tidyDialog(inst) }; if (duration != "" && $.effects && $.effects[showAnim]) { inst.dpDiv.hide(showAnim, $.datepicker._get(inst, "showOptions"), duration, postProcess) } else { inst.dpDiv[(duration == "" ? "hide" : (showAnim == "slideDown" ? "slideUp" : (showAnim == "fadeIn" ? "fadeOut" : "hide")))](duration, postProcess) } if (duration == "") { this._tidyDialog(inst) } var onClose = this._get(inst, "onClose"); if (onClose) { onClose.apply((inst.input ? inst.input[0] : null), [(inst.input ? inst.input.val() : ""), inst]) } this._datepickerShowing = false; this._lastInput = null; inst.settings.prompt = null; if (this._inDialog) { this._dialogInput.css({ position: "absolute", left: "0", top: "-100px" }); if ($.blockUI) { $.unblockUI(); $("body").append(this.dpDiv) } } this._inDialog = false } this._curInst = null }, _tidyDialog: function (inst) { inst.dpDiv.removeClass(this._dialogClass).unbind(".ui-datepicker"); $("." + this._promptClass, inst.dpDiv).remove() }, _checkExternalClick: function (event) { if (!$.datepicker._curInst) { return } var $target = $(event.target); if (($target.parents("#" + $.datepicker._mainDivId).length == 0) && !$target.hasClass($.datepicker.markerClassName) && !$target.hasClass($.datepicker._triggerClass) && $.datepicker._datepickerShowing && !($.datepicker._inDialog && $.blockUI)) { $.datepicker._hideDatepicker(null, "") } }, _adjustDate: function (id, offset, period) { var target = $(id); var inst = this._getInst(target[0]); this._adjustInstDate(inst, offset, period); this._updateDatepicker(inst) }, _gotoToday: function (id) { var target = $(id); var inst = this._getInst(target[0]); if (this._get(inst, "gotoCurrent") && inst.currentDay) { inst.selectedDay = inst.currentDay; inst.drawMonth = inst.selectedMonth = inst.currentMonth; inst.drawYear = inst.selectedYear = inst.currentYear } else { var date = new Date(); inst.selectedDay = date.getDate(); inst.drawMonth = inst.selectedMonth = date.getMonth(); inst.drawYear = inst.selectedYear = date.getFullYear() } this._notifyChange(inst); this._adjustDate(target) }, _selectMonthYear: function (id, select, period) {
            var target = $(id); var inst = this._getInst(target[0]); inst._selectingMonthYear = false;
            inst["selected" + (period == "M" ? "Month" : "Year")] = inst["draw" + (period == "M" ? "Month" : "Year")] = parseInt(select.options[select.selectedIndex].value, 10); this._notifyChange(inst); this._adjustDate(target)
        }, _clickMonthYear: function (id) { var target = $(id); var inst = this._getInst(target[0]); if (inst.input && inst._selectingMonthYear && !$.browser.msie) { inst.input[0].focus() } inst._selectingMonthYear = !inst._selectingMonthYear }, _changeFirstDay: function (id, day) { var target = $(id); var inst = this._getInst(target[0]); inst.settings.firstDay = day; this._updateDatepicker(inst) }, _selectDay: function (id, month, year, td) { if ($(td).hasClass(this._unselectableClass)) { return } var target = $(id); var inst = this._getInst(target[0]); var rangeSelect = this._get(inst, "rangeSelect"); if (rangeSelect) { inst.stayOpen = !inst.stayOpen; if (inst.stayOpen) { $(".ui-datepicker td", inst.dpDiv).removeClass(this._currentClass); $(td).addClass(this._currentClass) } } inst.selectedDay = inst.currentDay = $("a", td).html(); inst.selectedMonth = inst.currentMonth = month; inst.selectedYear = inst.currentYear = year; if (inst.stayOpen) { inst.endDay = inst.endMonth = inst.endYear = null } else { if (rangeSelect) { inst.endDay = inst.currentDay; inst.endMonth = inst.currentMonth; inst.endYear = inst.currentYear } } this._selectDate(id, this._formatDate(inst, inst.currentDay, inst.currentMonth, inst.currentYear)); if (inst.stayOpen) { inst.rangeStart = this._daylightSavingAdjust(new Date(inst.currentYear, inst.currentMonth, inst.currentDay)); this._updateDatepicker(inst) } else { if (rangeSelect) { inst.selectedDay = inst.currentDay = inst.rangeStart.getDate(); inst.selectedMonth = inst.currentMonth = inst.rangeStart.getMonth(); inst.selectedYear = inst.currentYear = inst.rangeStart.getFullYear(); inst.rangeStart = null; if (inst.inline) { this._updateDatepicker(inst) } } } }, _clearDate: function (id) { var target = $(id); var inst = this._getInst(target[0]); if (this._get(inst, "mandatory")) { return } inst.stayOpen = false; inst.endDay = inst.endMonth = inst.endYear = inst.rangeStart = null; this._selectDate(target, "") }, _selectDate: function (id, dateStr) { var target = $(id); var inst = this._getInst(target[0]); dateStr = (dateStr != null ? dateStr : this._formatDate(inst)); if (this._get(inst, "rangeSelect") && dateStr) { dateStr = (inst.rangeStart ? this._formatDate(inst, inst.rangeStart) : dateStr) + this._get(inst, "rangeSeparator") + dateStr } if (inst.input) { inst.input.val(dateStr) } this._updateAlternate(inst); var onSelect = this._get(inst, "onSelect"); if (onSelect) { onSelect.apply((inst.input ? inst.input[0] : null), [dateStr, inst]) } else { if (inst.input) { inst.input.trigger("change") } } if (inst.inline) { this._updateDatepicker(inst) } else { if (!inst.stayOpen) { this._hideDatepicker(null, this._get(inst, "duration")); this._lastInput = inst.input[0]; if (typeof (inst.input[0]) != "object") { inst.input[0].focus() } this._lastInput = null } } }, _updateAlternate: function (inst) {
            var altField = this._get(inst, "altField"); if (altField) {
                var altFormat = this._get(inst, "altFormat") || this._get(inst, "dateFormat");
                var date = this._getDate(inst); dateStr = (isArray(date) ? (!date[0] && !date[1] ? "" : this.formatDate(altFormat, date[0], this._getFormatConfig(inst)) + this._get(inst, "rangeSeparator") + this.formatDate(altFormat, date[1] || date[0], this._getFormatConfig(inst))) : this.formatDate(altFormat, date, this._getFormatConfig(inst))); $(altField).each(function () { $(this).val(dateStr) })
            }
        }, noWeekends: function (date) { var day = date.getDay(); return [(day > 0 && day < 6), ""] }, iso8601Week: function (date) { var checkDate = new Date(date.getFullYear(), date.getMonth(), date.getDate()); var firstMon = new Date(checkDate.getFullYear(), 1 - 1, 4); var firstDay = firstMon.getDay() || 7; firstMon.setDate(firstMon.getDate() + 1 - firstDay); if (firstDay < 4 && checkDate < firstMon) { checkDate.setDate(checkDate.getDate() - 3); return $.datepicker.iso8601Week(checkDate) } else { if (checkDate > new Date(checkDate.getFullYear(), 12 - 1, 28)) { firstDay = new Date(checkDate.getFullYear() + 1, 1 - 1, 4).getDay() || 7; if (firstDay > 4 && (checkDate.getDay() || 7) < firstDay - 3) { return 1 } } } return Math.floor(((checkDate - firstMon) / 86400000) / 7) + 1 }, dateStatus: function (date, inst) { return $.datepicker.formatDate($.datepicker._get(inst, "dateStatus"), date, $.datepicker._getFormatConfig(inst)) }, parseDate: function (format, value, settings) {
            if (format == null || value == null) { throw "Invalid arguments" } value = (typeof value == "object" ? value.toString() : value + ""); if (value == "") { return null } var shortYearCutoff = (settings ? settings.shortYearCutoff : null) || this._defaults.shortYearCutoff; var dayNamesShort = (settings ? settings.dayNamesShort : null) || this._defaults.dayNamesShort; var dayNames = (settings ? settings.dayNames : null) || this._defaults.dayNames; var monthNamesShort = (settings ? settings.monthNamesShort : null) || this._defaults.monthNamesShort; var monthNames = (settings ? settings.monthNames : null) || this._defaults.monthNames; var year = -1; var month = -1; var day = -1; var doy = -1; var literal = false; var lookAhead = function (match) { var matches = (iFormat + 1 < format.length && format.charAt(iFormat + 1) == match); if (matches) { iFormat++ } return matches }; var getNumber = function (match) { lookAhead(match); var origSize = (match == "@" ? 14 : (match == "y" ? 4 : (match == "o" ? 3 : 2))); var size = origSize; var num = 0; while (size > 0 && iValue < value.length && value.charAt(iValue) >= "0" && value.charAt(iValue) <= "9") { num = num * 10 + parseInt(value.charAt(iValue++), 10); size-- } if (size == origSize) { throw "Missing number at position " + iValue } return num }; var getName = function (match, shortNames, longNames) { var names = (lookAhead(match) ? longNames : shortNames); var size = 0; for (var j = 0; j < names.length; j++) { size = Math.max(size, names[j].length) } var name = ""; var iInit = iValue; while (size > 0 && iValue < value.length) { name += value.charAt(iValue++); for (var i = 0; i < names.length; i++) { if (name == names[i]) { return i + 1 } } size-- } throw "Unknown name at position " + iInit }; var checkLiteral = function () { if (value.charAt(iValue) != format.charAt(iFormat)) { throw "Unexpected literal at position " + iValue } iValue++ }; var iValue = 0; for (var iFormat = 0; iFormat < format.length; iFormat++) {
                if (literal) {
                    if (format.charAt(iFormat) == "'" && !lookAhead("'")) { literal = false } else { checkLiteral() }
                } else { switch (format.charAt(iFormat)) { case "d": day = getNumber("d"); break; case "D": getName("D", dayNamesShort, dayNames); break; case "o": doy = getNumber("o"); break; case "m": month = getNumber("m"); break; case "M": month = getName("M", monthNamesShort, monthNames); break; case "y": year = getNumber("y"); break; case "@": var date = new Date(getNumber("@")); year = date.getFullYear(); month = date.getMonth() + 1; day = date.getDate(); break; case "'": if (lookAhead("'")) { checkLiteral() } else { literal = true } break; default: checkLiteral() } }
            } if (year == -1) { year = new Date().getFullYear() } else { if (year < 100) { year += new Date().getFullYear() - new Date().getFullYear() % 100 + (year <= shortYearCutoff ? 0 : -100) } } if (doy > -1) { month = 1; day = doy; do { var dim = this._getDaysInMonth(year, month - 1); if (day <= dim) { break } month++; day -= dim } while (true) } var date = this._daylightSavingAdjust(new Date(year, month - 1, day)); if (date.getFullYear() != year || date.getMonth() + 1 != month || date.getDate() != day) { throw "Invalid date" } return date
        }, ATOM: "yy-mm-dd", COOKIE: "D, dd M yy", ISO_8601: "yy-mm-dd", RFC_822: "D, d M y", RFC_850: "DD, dd-M-y", RFC_1036: "D, d M y", RFC_1123: "D, d M yy", RFC_2822: "D, d M yy", RSS: "D, d M y", TIMESTAMP: "@", W3C: "yy-mm-dd", formatDate: function (format, date, settings) { if (!date) { return "" } var dayNamesShort = (settings ? settings.dayNamesShort : null) || this._defaults.dayNamesShort; var dayNames = (settings ? settings.dayNames : null) || this._defaults.dayNames; var monthNamesShort = (settings ? settings.monthNamesShort : null) || this._defaults.monthNamesShort; var monthNames = (settings ? settings.monthNames : null) || this._defaults.monthNames; var lookAhead = function (match) { var matches = (iFormat + 1 < format.length && format.charAt(iFormat + 1) == match); if (matches) { iFormat++ } return matches }; var formatNumber = function (match, value, len) { var num = "" + value; if (lookAhead(match)) { while (num.length < len) { num = "0" + num } } return num }; var formatName = function (match, value, shortNames, longNames) { return (lookAhead(match) ? longNames[value] : shortNames[value]) }; var output = ""; var literal = false; if (date) { for (var iFormat = 0; iFormat < format.length; iFormat++) { if (literal) { if (format.charAt(iFormat) == "'" && !lookAhead("'")) { literal = false } else { output += format.charAt(iFormat) } } else { switch (format.charAt(iFormat)) { case "d": output += formatNumber("d", date.getDate(), 2); break; case "D": output += formatName("D", date.getDay(), dayNamesShort, dayNames); break; case "o": var doy = date.getDate(); for (var m = date.getMonth() - 1; m >= 0; m--) { doy += this._getDaysInMonth(date.getFullYear(), m) } output += formatNumber("o", doy, 3); break; case "m": output += formatNumber("m", date.getMonth() + 1, 2); break; case "M": output += formatName("M", date.getMonth(), monthNamesShort, monthNames); break; case "y": output += (lookAhead("y") ? date.getFullYear() : (date.getYear() % 100 < 10 ? "0" : "") + date.getYear() % 100); break; case "@": output += date.getTime(); break; case "'": if (lookAhead("'")) { output += "'" } else { literal = true } break; default: output += format.charAt(iFormat) } } } } return output }, _possibleChars: function (format) { var chars = ""; var literal = false; for (var iFormat = 0; iFormat < format.length; iFormat++) { if (literal) { if (format.charAt(iFormat) == "'" && !lookAhead("'")) { literal = false } else { chars += format.charAt(iFormat) } } else { switch (format.charAt(iFormat)) { case "d": case "m": case "y": case "@": chars += "0123456789"; break; case "D": case "M": return null; case "'": if (lookAhead("'")) { chars += "'" } else { literal = true } break; default: chars += format.charAt(iFormat) } } } return chars }, _get: function (inst, name) { return inst.settings[name] !== undefined ? inst.settings[name] : this._defaults[name] }, _setDateFromField: function (inst) {
            var dateFormat = this._get(inst, "dateFormat");
            var dates = inst.input ? inst.input.val().split(this._get(inst, "rangeSeparator")) : null; inst.endDay = inst.endMonth = inst.endYear = null; var date = defaultDate = this._getDefaultDate(inst); if (dates.length > 0) { var settings = this._getFormatConfig(inst); if (dates.length > 1) { date = this.parseDate(dateFormat, dates[1], settings) || defaultDate; inst.endDay = date.getDate(); inst.endMonth = date.getMonth(); inst.endYear = date.getFullYear() } try { date = this.parseDate(dateFormat, dates[0], settings) || defaultDate } catch (event) { this.log(event); date = defaultDate } } inst.selectedDay = date.getDate(); inst.drawMonth = inst.selectedMonth = date.getMonth(); inst.drawYear = inst.selectedYear = date.getFullYear(); inst.currentDay = (dates[0] ? date.getDate() : 0); inst.currentMonth = (dates[0] ? date.getMonth() : 0); inst.currentYear = (dates[0] ? date.getFullYear() : 0); this._adjustInstDate(inst)
        }, _getDefaultDate: function (inst) { var date = this._determineDate(this._get(inst, "defaultDate"), new Date()); var minDate = this._getMinMaxDate(inst, "min", true); var maxDate = this._getMinMaxDate(inst, "max"); date = (minDate && date < minDate ? minDate : date); date = (maxDate && date > maxDate ? maxDate : date); return date }, _determineDate: function (date, defaultDate) { var offsetNumeric = function (offset) { var date = new Date(); date.setDate(date.getDate() + offset); return date }; var offsetString = function (offset, getDaysInMonth) { var date = new Date(); var year = date.getFullYear(); var month = date.getMonth(); var day = date.getDate(); var pattern = /([+-]?[0-9]+)\s*(d|D|w|W|m|M|y|Y)?/g; var matches = pattern.exec(offset); while (matches) { switch (matches[2] || "d") { case "d": case "D": day += parseInt(matches[1], 10); break; case "w": case "W": day += parseInt(matches[1], 10) * 7; break; case "m": case "M": month += parseInt(matches[1], 10); day = Math.min(day, getDaysInMonth(year, month)); break; case "y": case "Y": year += parseInt(matches[1], 10); day = Math.min(day, getDaysInMonth(year, month)); break } matches = pattern.exec(offset) } return new Date(year, month, day) }; date = (date == null ? defaultDate : (typeof date == "string" ? offsetString(date, this._getDaysInMonth) : (typeof date == "number" ? (isNaN(date) ? defaultDate : offsetNumeric(date)) : date))); date = (date && date.toString() == "Invalid Date" ? defaultDate : date); if (date) { date.setHours(0); date.setMinutes(0); date.setSeconds(0); date.setMilliseconds(0) } return this._daylightSavingAdjust(date) }, _daylightSavingAdjust: function (date) { if (!date) { return null } date.setHours(date.getHours() > 12 ? date.getHours() + 2 : 0); return date }, _setDate: function (inst, date, endDate) { var clear = !(date); var origMonth = inst.selectedMonth; var origYear = inst.selectedYear; date = this._determineDate(date, new Date()); inst.selectedDay = inst.currentDay = date.getDate(); inst.drawMonth = inst.selectedMonth = inst.currentMonth = date.getMonth(); inst.drawYear = inst.selectedYear = inst.currentYear = date.getFullYear(); if (this._get(inst, "rangeSelect")) { if (endDate) { endDate = this._determineDate(endDate, null); inst.endDay = endDate.getDate(); inst.endMonth = endDate.getMonth(); inst.endYear = endDate.getFullYear() } else { inst.endDay = inst.currentDay; inst.endMonth = inst.currentMonth; inst.endYear = inst.currentYear } } if (origMonth != inst.selectedMonth || origYear != inst.selectedYear) { this._notifyChange(inst) } this._adjustInstDate(inst); if (inst.input) { inst.input.val(clear ? "" : this._formatDate(inst) + (!this._get(inst, "rangeSelect") ? "" : this._get(inst, "rangeSeparator") + this._formatDate(inst, inst.endDay, inst.endMonth, inst.endYear))) } }, _getDate: function (inst) {
            var startDate = (!inst.currentYear || (inst.input && inst.input.val() == "") ? null : this._daylightSavingAdjust(new Date(inst.currentYear, inst.currentMonth, inst.currentDay)));
            if (this._get(inst, "rangeSelect")) { return [inst.rangeStart || startDate, (!inst.endYear ? inst.rangeStart || startDate : this._daylightSavingAdjust(new Date(inst.endYear, inst.endMonth, inst.endDay)))] } else { return startDate }
        }, _generateHTML: function (inst) {
            var today = new Date(); today = this._daylightSavingAdjust(new Date(today.getFullYear(), today.getMonth(), today.getDate())); var showStatus = this._get(inst, "showStatus"); var initStatus = this._get(inst, "initStatus") || "&#xa0;"; var isRTL = this._get(inst, "isRTL"); var clear = (this._get(inst, "mandatory") ? "" : '<div class="ui-datepicker-clear"><a onclick="KSQ.datepicker._clearDate(\'#' + inst.id + "');\"" + this._addStatus(showStatus, inst.id, this._get(inst, "clearStatus"), initStatus) + ">" + this._get(inst, "clearText") + "</a></div>"); var controls = '<div class="ui-datepicker-control">' + (isRTL ? "" : clear) + '<div class="ui-datepicker-close"><a onclick="KSQ.datepicker._hideDatepicker();"' + this._addStatus(showStatus, inst.id, this._get(inst, "closeStatus"), initStatus) + ">" + this._get(inst, "closeText") + "</a></div>" + (isRTL ? clear : "") + "</div>"; var prompt = this._get(inst, "prompt"); var closeAtTop = this._get(inst, "closeAtTop"); var hideIfNoPrevNext = this._get(inst, "hideIfNoPrevNext"); var navigationAsDateFormat = this._get(inst, "navigationAsDateFormat"); var showBigPrevNext = this._get(inst, "showBigPrevNext"); var numMonths = this._getNumberOfMonths(inst); var showCurrentAtPos = this._get(inst, "showCurrentAtPos"); var stepMonths = this._get(inst, "stepMonths"); var stepBigMonths = this._get(inst, "stepBigMonths"); var isMultiMonth = (numMonths[0] != 1 || numMonths[1] != 1); var currentDate = this._daylightSavingAdjust((!inst.currentDay ? new Date(9999, 9, 9) : new Date(inst.currentYear, inst.currentMonth, inst.currentDay))); var minDate = this._getMinMaxDate(inst, "min", true); var maxDate = this._getMinMaxDate(inst, "max"); var drawMonth = inst.drawMonth - showCurrentAtPos; var drawYear = inst.drawYear; if (drawMonth < 0) { drawMonth += 12; drawYear-- } if (maxDate) { var maxDraw = this._daylightSavingAdjust(new Date(maxDate.getFullYear(), maxDate.getMonth() - numMonths[1] + 1, maxDate.getDate())); maxDraw = (minDate && maxDraw < minDate ? minDate : maxDraw); while (this._daylightSavingAdjust(new Date(drawYear, drawMonth, 1)) > maxDraw) { drawMonth--; if (drawMonth < 0) { drawMonth = 11; drawYear-- } } } var prevText = this._get(inst, "prevText"); prevText = (!navigationAsDateFormat ? prevText : this.formatDate(prevText, this._daylightSavingAdjust(new Date(drawYear, drawMonth - stepMonths, 1)), this._getFormatConfig(inst))); var prevBigText = (showBigPrevNext ? this._get(inst, "prevBigText") : ""); prevBigText = (!navigationAsDateFormat ? prevBigText : this.formatDate(prevBigText, this._daylightSavingAdjust(new Date(drawYear, drawMonth - stepBigMonths, 1)), this._getFormatConfig(inst)));
            var prev = '<div class="ui-datepicker-prev">' + (this._canAdjustMonth(inst, -1, drawYear, drawMonth) ? (showBigPrevNext ? "<a onclick=\"KSQ.datepicker._adjustDate('#" + inst.id + "', -" + stepBigMonths + ", 'M');\"" + this._addStatus(showStatus, inst.id, this._get(inst, "prevBigStatus"), initStatus) + ">" + prevBigText + "</a>" : "") + "<a onclick=\"KSQ.datepicker._adjustDate('#" + inst.id + "', -" + stepMonths + ", 'M');\"" + this._addStatus(showStatus, inst.id, this._get(inst, "prevStatus"), initStatus) + ">" + prevText + "</a>" : (hideIfNoPrevNext ? "" : (showBigPrevNext ? "<label>" + prevBigText + "</label>" : "") + "<label>" + prevText + "</label>")) + "</div>"; var nextText = this._get(inst, "nextText"); nextText = (!navigationAsDateFormat ? nextText : this.formatDate(nextText, this._daylightSavingAdjust(new Date(drawYear, drawMonth + stepMonths, 1)), this._getFormatConfig(inst))); var nextBigText = (showBigPrevNext ? this._get(inst, "nextBigText") : ""); nextBigText = (!navigationAsDateFormat ? nextBigText : this.formatDate(nextBigText, this._daylightSavingAdjust(new Date(drawYear, drawMonth + stepBigMonths, 1)), this._getFormatConfig(inst))); var next = '<div class="ui-datepicker-next">' + (this._canAdjustMonth(inst, +1, drawYear, drawMonth) ? "<a onclick=\"KSQ.datepicker._adjustDate('#" + inst.id + "', +" + stepMonths + ", 'M');\"" + this._addStatus(showStatus, inst.id, this._get(inst, "nextStatus"), initStatus) + ">" + nextText + "</a>" + (showBigPrevNext ? "<a onclick=\"KSQ.datepicker._adjustDate('#" + inst.id + "', +" + stepBigMonths + ", 'M');\"" + this._addStatus(showStatus, inst.id, this._get(inst, "nextBigStatus"), initStatus) + ">" + nextBigText + "</a>" : "") : (hideIfNoPrevNext ? "" : "<label>" + nextText + "</label>" + (showBigPrevNext ? "<label>" + nextBigText + "</label>" : ""))) + "</div>"; var currentText = this._get(inst, "currentText"); var gotoDate = (this._get(inst, "gotoCurrent") && inst.currentDay ? currentDate : today); currentText = (!navigationAsDateFormat ? currentText : this.formatDate(currentText, gotoDate, this._getFormatConfig(inst))); var html = (closeAtTop && !inst.inline ? controls : "") + '<div class="ui-datepicker-links">' + (isRTL ? next : prev) + (this._isInRange(inst, gotoDate) ? '<div class="ui-datepicker-current"><a onclick="KSQ.datepicker._gotoToday(\'#' + inst.id + "');\"" + this._addStatus(showStatus, inst.id, this._get(inst, "currentStatus"), initStatus) + ">" + currentText + "</a></div>" : "") + (isRTL ? prev : next) + "</div>" + (prompt ? '<div class="' + this._promptClass + '"><span>' + prompt + "</span></div>" : ""); var firstDay = parseInt(this._get(inst, "firstDay")); firstDay = (isNaN(firstDay) ? 0 : firstDay); var changeFirstDay = this._get(inst, "changeFirstDay"); var dayNames = this._get(inst, "dayNames"); var dayNamesShort = this._get(inst, "dayNamesShort");
            var dayNamesMin = this._get(inst, "dayNamesMin"); var monthNames = this._get(inst, "monthNames");
            var beforeShowDay = this._get(inst, "beforeShowDay"); var highlightWeek = this._get(inst, "highlightWeek"); var showOtherMonths = this._get(inst, "showOtherMonths"); var showWeeks = this._get(inst, "showWeeks"); var calculateWeek = this._get(inst, "calculateWeek") || this.iso8601Week; var weekStatus = this._get(inst, "weekStatus"); var status = (showStatus ? this._get(inst, "dayStatus") || initStatus : ""); var dateStatus = this._get(inst, "statusForDate") || this.dateStatus; var endDate = inst.endDay ? this._daylightSavingAdjust(new Date(inst.endYear, inst.endMonth, inst.endDay)) : currentDate; var defaultDate = this._getDefaultDate(inst); for (var row = 0; row < numMonths[0]; row++) {
                for (var col = 0; col < numMonths[1]; col++) {
                    var selectedDate = this._daylightSavingAdjust(new Date(drawYear, drawMonth, inst.selectedDay)); html += '<div class="ui-datepicker-one-month' + (col == 0 ? " ui-datepicker-new-row" : "") + '">' + this._generateMonthYearHeader(inst, drawMonth, drawYear, minDate, maxDate, selectedDate, row > 0 || col > 0, showStatus, initStatus, monthNames) + '<table class="ui-datepicker" cellpadding="0" cellspacing="0"><thead><tr class="ui-datepicker-title-row">' + (showWeeks ? "<td" + this._addStatus(showStatus, inst.id, weekStatus, initStatus) + ">" + this._get(inst, "weekHeader") + "</td>" : ""); for (var dow = 0; dow < 7; dow++) { var day = (dow + firstDay) % 7; var dayStatus = (status.indexOf("DD") > -1 ? status.replace(/DD/, dayNames[day]) : status.replace(/D/, dayNamesShort[day])); html += "<td" + ((dow + firstDay + 6) % 7 >= 5 ? ' class="ui-datepicker-week-end-cell"' : "") + ">" + (!changeFirstDay ? "<span" : "<a onclick=\"KSQ.datepicker._changeFirstDay('#" + inst.id + "', " + day + ');"') + this._addStatus(showStatus, inst.id, dayStatus, initStatus) + ' title="' + dayNames[day] + '">' + dayNamesMin[day] + (changeFirstDay ? "</a>" : "</span>") + "</td>" } html += "</tr></thead><tbody>"; var daysInMonth = this._getDaysInMonth(drawYear, drawMonth); if (drawYear == inst.selectedYear && drawMonth == inst.selectedMonth) { inst.selectedDay = Math.min(inst.selectedDay, daysInMonth) } var leadDays = (this._getFirstDayOfMonth(drawYear, drawMonth) - firstDay + 7) % 7; var numRows = (isMultiMonth ? 6 : Math.ceil((leadDays + daysInMonth) / 7)); var printDate = this._daylightSavingAdjust(new Date(drawYear, drawMonth, 1 - leadDays)); for (var dRow = 0; dRow < numRows; dRow++) {
                        html += '<tr class="ui-datepicker-days-row">' + (showWeeks ? '<td class="ui-datepicker-week-col"' + this._addStatus(showStatus, inst.id, weekStatus, initStatus) + ">" + calculateWeek(printDate) + "</td>" : ""); for (var dow = 0; dow < 7; dow++) {
                            var daySettings = (beforeShowDay ? beforeShowDay.apply((inst.input ? inst.input[0] : null), [printDate]) : [true, ""]); var otherMonth = (printDate.getMonth() != drawMonth);
                            var unselectable = otherMonth || !daySettings[0] || (minDate && printDate < minDate) || (maxDate && printDate > maxDate); html += '<td class="ui-datepicker-days-cell' + ((dow + firstDay + 6) % 7 >= 5 ? " ui-datepicker-week-end-cell" : "") + (otherMonth ? " ui-datepicker-other-month" : "") + ((printDate.getTime() == selectedDate.getTime() && drawMonth == inst.selectedMonth && inst._keyEvent) || (defaultDate.getTime() == printDate.getTime() && defaultDate.getTime() == selectedDate.getTime()) ? " " + $.datepicker._dayOverClass : "") + (unselectable ? " " + this._unselectableClass : "") + (otherMonth && !showOtherMonths ? "" : " " + daySettings[1] + (printDate.getTime() >= currentDate.getTime() && printDate.getTime() <= endDate.getTime() ? " " + this._currentClass : "") + (printDate.getTime() == today.getTime() ? " ui-datepicker-today" : "")) + '"' + ((!otherMonth || showOtherMonths) && daySettings[2] ? ' title="' + daySettings[2] + '"' : "") + (unselectable ? (highlightWeek ? " onmouseover=\"KSQ(this).parent().addClass('" + this._weekOverClass + "');\" onmouseout=\"KSQ(this).parent().removeClass('" + this._weekOverClass + "');\"" : "") : " onmouseover=\"KSQ(this).addClass('" + this._dayOverClass + "')" + (highlightWeek ? ".parent().addClass('" + this._weekOverClass + "')" : "") + ";" + (!showStatus || (otherMonth && !showOtherMonths) ? "" : "KSQ('#ui-datepicker-status-" + inst.id + "').html('" + (dateStatus.apply((inst.input ? inst.input[0] : null), [printDate, inst]) || initStatus) + "');") + '" onmouseout="KSQ(this).removeClass(\'' + this._dayOverClass + "')" + (highlightWeek ? ".parent().removeClass('" + this._weekOverClass + "')" : "") + ";" + (!showStatus || (otherMonth && !showOtherMonths) ? "" : "KSQ('#ui-datepicker-status-" + inst.id + "').html('" + initStatus + "');") + '" onclick="KSQ.datepicker._selectDay(\'#' + inst.id + "'," + drawMonth + "," + drawYear + ', this);"') + ">" + (otherMonth ? (showOtherMonths ? printDate.getDate() : "&#xa0;") : (unselectable ? printDate.getDate() : "<a>" + printDate.getDate() + "</a>")) + "</td>"; printDate.setDate(printDate.getDate() + 1); printDate = this._daylightSavingAdjust(printDate)
                        } html += "</tr>"
                    } drawMonth++; if (drawMonth > 11) { drawMonth = 0; drawYear++ } html += "</tbody></table></div>"
                }
            } html += (showStatus ? '<div style="clear: both;"></div><div id="ui-datepicker-status-' + inst.id + '" class="ui-datepicker-status">' + initStatus + "</div>" : "") + (!closeAtTop && !inst.inline ? controls : "") + '<div style="clear: both;"></div>' + ($.browser.msie && parseInt($.browser.version, 10) < 7 && !inst.inline ? '<iframe src="javascript:false;" class="ui-datepicker-cover"></iframe>' : ""); inst._keyEvent = false; return html
        }, _generateMonthYearHeader: function (inst, drawMonth, drawYear, minDate, maxDate, selectedDate, secondary, showStatus, initStatus, monthNames) { minDate = (inst.rangeStart && minDate && selectedDate < minDate ? selectedDate : minDate); var changeMonth = this._get(inst, "changeMonth"); var changeYear = this._get(inst, "changeYear"); var showMonthAfterYear = this._get(inst, "showMonthAfterYear"); var html = '<div class="ui-datepicker-header">'; var monthHtml = ""; if (secondary || !changeMonth) { monthHtml += monthNames[drawMonth] } else { var inMinYear = (minDate && minDate.getFullYear() == drawYear); var inMaxYear = (maxDate && maxDate.getFullYear() == drawYear); monthHtml += '<select class="ui-datepicker-new-month" onchange="KSQ.datepicker._selectMonthYear(\'#' + inst.id + "', this, 'M');\" onclick=\"KSQ.datepicker._clickMonthYear('#" + inst.id + "');\"" + this._addStatus(showStatus, inst.id, this._get(inst, "monthStatus"), initStatus) + ">"; for (var month = 0; month < 12; month++) { if ((!inMinYear || month >= minDate.getMonth()) && (!inMaxYear || month <= maxDate.getMonth())) { monthHtml += '<option value="' + month + '"' + (month == drawMonth ? ' selected="selected"' : "") + ">" + monthNames[month] + "</option>" } } monthHtml += "</select>" } if (!showMonthAfterYear) { html += monthHtml + (secondary || changeMonth || changeYear ? "&#xa0;" : "") } if (secondary || !changeYear) { html += drawYear } else { var years = this._get(inst, "yearRange").split(":"); var year = 0; var endYear = 0; if (years.length != 2) { year = drawYear - 10; endYear = drawYear + 10 } else { if (years[0].charAt(0) == "+" || years[0].charAt(0) == "-") { year = endYear = new Date().getFullYear(); year += parseInt(years[0], 10); endYear += parseInt(years[1], 10) } else { year = parseInt(years[0], 10); endYear = parseInt(years[1], 10) } } year = (minDate ? Math.max(year, minDate.getFullYear()) : year); endYear = (maxDate ? Math.min(endYear, maxDate.getFullYear()) : endYear); html += '<select class="ui-datepicker-new-year" onchange="KSQ.datepicker._selectMonthYear(\'#' + inst.id + "', this, 'Y');\" onclick=\"KSQ.datepicker._clickMonthYear('#" + inst.id + "');\"" + this._addStatus(showStatus, inst.id, this._get(inst, "yearStatus"), initStatus) + ">"; for (; year <= endYear; year++) { html += '<option value="' + year + '"' + (year == drawYear ? ' selected="selected"' : "") + ">" + year + "</option>" } html += "</select>" } if (showMonthAfterYear) { html += (secondary || changeMonth || changeYear ? "&#xa0;" : "") + monthHtml } html += "</div>"; return html },
        _addStatus: function (showStatus, id, text, initStatus) { return (showStatus ? " onmouseover=\"KSQ('#ui-datepicker-status-" + id + "').html('" + (text || initStatus) + "');\" onmouseout=\"KSQ('#ui-datepicker-status-" + id + "').html('" + initStatus + "');\"" : "") }, _adjustInstDate: function (inst, offset, period) { var year = inst.drawYear + (period == "Y" ? offset : 0); var month = inst.drawMonth + (period == "M" ? offset : 0); var day = Math.min(inst.selectedDay, this._getDaysInMonth(year, month)) + (period == "D" ? offset : 0); var date = this._daylightSavingAdjust(new Date(year, month, day)); var minDate = this._getMinMaxDate(inst, "min", true); var maxDate = this._getMinMaxDate(inst, "max"); date = (minDate && date < minDate ? minDate : date); date = (maxDate && date > maxDate ? maxDate : date); inst.selectedDay = date.getDate(); inst.drawMonth = inst.selectedMonth = date.getMonth(); inst.drawYear = inst.selectedYear = date.getFullYear(); if (period == "M" || period == "Y") { this._notifyChange(inst) } }, _notifyChange: function (inst) { var onChange = this._get(inst, "onChangeMonthYear"); if (onChange) { onChange.apply((inst.input ? inst.input[0] : null), [inst.selectedYear, inst.selectedMonth + 1, inst]) } }, _getNumberOfMonths: function (inst) { var numMonths = this._get(inst, "numberOfMonths"); return (numMonths == null ? [1, 1] : (typeof numMonths == "number" ? [1, numMonths] : numMonths)) }, _getMinMaxDate: function (inst, minMax, checkRange) { var date = this._determineDate(this._get(inst, minMax + "Date"), null); return (!checkRange || !inst.rangeStart ? date : (!date || inst.rangeStart > date ? inst.rangeStart : date)) }, _getDaysInMonth: function (year, month) { return 32 - new Date(year, month, 32).getDate() }, _getFirstDayOfMonth: function (year, month) { return new Date(year, month, 1).getDay() }, _canAdjustMonth: function (inst, offset, curYear, curMonth) { var numMonths = this._getNumberOfMonths(inst); var date = this._daylightSavingAdjust(new Date(curYear, curMonth + (offset < 0 ? offset : numMonths[1]), 1)); if (offset < 0) { date.setDate(this._getDaysInMonth(date.getFullYear(), date.getMonth())) } return this._isInRange(inst, date) }, _isInRange: function (inst, date) { var newMinDate = (!inst.rangeStart ? null : this._daylightSavingAdjust(new Date(inst.selectedYear, inst.selectedMonth, inst.selectedDay))); newMinDate = (newMinDate && inst.rangeStart < newMinDate ? inst.rangeStart : newMinDate); var minDate = newMinDate || this._getMinMaxDate(inst, "min"); var maxDate = this._getMinMaxDate(inst, "max"); return ((!minDate || date >= minDate) && (!maxDate || date <= maxDate)) }, _getFormatConfig: function (inst) {
            var shortYearCutoff = this._get(inst, "shortYearCutoff"); shortYearCutoff = (typeof shortYearCutoff != "string" ? shortYearCutoff : new Date().getFullYear() % 100 + parseInt(shortYearCutoff, 10));
            return { shortYearCutoff: shortYearCutoff, dayNamesShort: this._get(inst, "dayNamesShort"), dayNames: this._get(inst, "dayNames"), monthNamesShort: this._get(inst, "monthNamesShort"), monthNames: this._get(inst, "monthNames") }
        }, _formatDate: function (inst, day, month, year) { if (!day) { inst.currentDay = inst.selectedDay; inst.currentMonth = inst.selectedMonth; inst.currentYear = inst.selectedYear } var date = (day ? (typeof day == "object" ? day : this._daylightSavingAdjust(new Date(year, month, day))) : this._daylightSavingAdjust(new Date(inst.currentYear, inst.currentMonth, inst.currentDay))); return this.formatDate(this._get(inst, "dateFormat"), date, this._getFormatConfig(inst)) }
    }); function extendRemove(target, props) { $.extend(target, props); for (var name in props) { if (props[name] == null || props[name] == undefined) { target[name] = props[name] } } return target } function isArray(a) { return (a && (($.browser.safari && typeof a == "object" && a.length) || (a.constructor && a.constructor.toString().match(/\Array\(\)/)))) } $.fn.datepicker = function (options) { if (!$.datepicker.initialized) { $(document.body).append($.datepicker.dpDiv).mousedown($.datepicker._checkExternalClick); $.datepicker.initialized = true } var otherArgs = Array.prototype.slice.call(arguments, 1); if (typeof options == "string" && (options == "isDisabled" || options == "getDate")) { return $.datepicker["_" + options + "Datepicker"].apply($.datepicker, [this[0]].concat(otherArgs)) } return this.each(function () { typeof options == "string" ? $.datepicker["_" + options + "Datepicker"].apply($.datepicker, [this].concat(otherArgs)) : $.datepicker._attachDatepicker(this, options) }) }; $.datepicker = new Datepicker(); $.datepicker.initialized = false; $.datepicker.uuid = new Date().getTime(); $.datepicker.version = "1.6"
})(KSQ);

/* ]]> */
