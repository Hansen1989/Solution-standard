
F.ready(function () {
    // IDS：default.aspx.cs 中向页面输出的控件客户端ID集合
    var btnExpandAll = F(IDS.btnExpandAll);
    var btnCollapseAll = F(IDS.btnCollapseAll);
    var mainMenu = F(IDS.mainMenu);
    var mainTabStrip = F(IDS.mainTabStrip);
    var windowSourceCode = F(IDS.windowSourceCode);
    var leftRegion = F(IDS.leftRegion);
    var menuSettings = F(IDS.menuSettings);

    
    if (window.Ext) {
        F.Button = Ext.Button;
        F.Toolbar = Ext.Toolbar;
    }


    // 当前展开的手风琴面板
    function getExpandedPanel() {
        var panel = null;
        mainMenu.items.each(function (item) {
            if (!item.getCollapsed()) {
                panel = item;
            }
        });
        return panel;
    }

    // 点击展开菜单
    btnExpandAll.on('click', function () {
        if (IDS.menuType == 'menu') {
            // 左侧为树控件
            mainMenu.expandAll();
        } else {
            // 左侧为树控件+手风琴控件
            var expandedPanel = getExpandedPanel();
            if (expandedPanel) {
                expandedPanel.items.getAt(0).expandAll();
            }
        }
    });

    // 点击折叠菜单
    btnCollapseAll.on('click', function () {
        if (IDS.menuType == 'menu') {
            // 左侧为树控件
            mainMenu.collapseAll();
        } else {
            // 左侧为树控件+手风琴控件
            var expandedPanel = getExpandedPanel();
            if (expandedPanel) {
                expandedPanel.items.getAt(0).collapseAll();
            }
        }
    });


    function createToolbar(tabConfig) {

        // 由工具栏上按钮获得当前标签页中的iframe节点
        function getCurrentIFrameNode(btn) {
            return $('#' + btn.id).parents('.f-tab').find('iframe');
        }

        var sourcecodeButton = new F.Button({
            text: '源代码',
            type: 'button',
            icon: './icon/page_white_code.png',
            listeners: {
                click: function () {
                    var iframeNode = getCurrentIFrameNode(this);
                    var iframeWnd = iframeNode[0].contentWindow

                    var files = [iframeNode.attr('src')];
                    var sourcefilesNode = $(iframeWnd.document).find('head meta[name=sourcefiles]');
                    if (sourcefilesNode.length) {
                        $.merge(files, sourcefilesNode.attr('content').split(';'));
                    }
                    windowSourceCode.f_show('./common/source.aspx?files=' + encodeURIComponent(files.join(';')));
                }
            }
        });

        var openNewWindowButton = new F.Button({
            text: '新标签页中打开',
            type: 'button',
            icon: './icon/tab_go.png',
            listeners: {
                click: function () {
                    var iframeNode = getCurrentIFrameNode(this);
                    window.open(iframeNode.attr('src'), '_blank');
                }
            }
        });

        var refreshButton = new F.Button({
            text: '刷新',
            type: 'button',
            icon: './icon/reload.png',
            listeners: {
                click: function () {
                    var iframeNode = getCurrentIFrameNode(this);
                    iframeNode[0].contentWindow.location.reload();
                }
            }
        });

        var toolbar = new F.Toolbar({
            items: ['->', sourcecodeButton, '-', refreshButton, '-', openNewWindowButton]
        });

        tabConfig['tbar'] = toolbar;
    }



    // 初始化主框架中的树(或者Accordion+Tree)和选项卡互动，以及地址栏的更新
    // treeMenu： 主框架中的树控件实例，或者内嵌树控件的手风琴控件实例
    // mainTabStrip： 选项卡实例
    // createToolbar： 创建选项卡前的回调函数（接受tabConfig参数）
    // updateLocationHash: 切换Tab时，是否更新地址栏Hash值
    // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
    // refreshWhenTabChange: 切换选项卡时，是否刷新内部IFrame
    F.util.initTreeTabStrip(mainMenu, mainTabStrip, createToolbar, true, false, false);



    // 添加示例标签页
    window.addExampleTab = function (id, url, text, icon, refreshWhenExist) {
        // 动态添加一个标签页
        // mainTabStrip： 选项卡实例
        // id： 选项卡ID
        // url: 选项卡IFrame地址 
        // text： 选项卡标题
        // icon： 选项卡图标
        // addTabCallback： 创建选项卡前的回调函数（接受tabConfig参数）
        // refreshWhenExist： 添加选项卡时，如果选项卡已经存在，是否刷新内部IFrame
        F.util.addMainTab(mainTabStrip, id, url, text, icon, null, refreshWhenExist);
    };

    // 移除选中标签页
    window.removeActiveTab = function () {
        var activeTab = mainTabStrip.getActiveTab();
        mainTabStrip.removeTab(activeTab.id);
    };


    // 添加工具图标，并在点击时显示上下文菜单
    leftRegion.addTool({
        type: 'gear',
        tooltip: '系统设置',
        regionTool: true,
        handler: function (event, toolEl, panelHeader) {
            menuSettings.showBy(this);
        }
    });



});
